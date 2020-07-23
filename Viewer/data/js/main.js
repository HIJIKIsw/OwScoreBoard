//------------------------------------------------------------------------------
// main.js
//------------------------------------------------------------------------------

	var xhr = new XMLHttpRequest();
	var ScoreFile;
	var OldScoreFile;
	var ConfigFile;
	var OldConfigFile;
	var Elements;
	var IsPlaying = false;
	var ScoreFilePath = "./score.json";
	var ConfigFilePath = "./config.json";

	//--------------------------------------------------------------------------
	// Initialize
	//--------------------------------------------------------------------------
	function Initialize()
	{
		// はじめにすべてのボードを非表示に
		$('.Board').hide();

		Elements = {
			Wins1:	$('#ScoreBoard .Score .Win'),
			Wins2:	$('#Scores .Score .Win'),
			Loses1: $('#ScoreBoard .Score .Lose'),
			Loses2:	$('#Scores .Score .Lose'),
			Draws1:	$('#ScoreBoard .Score .Draw'),
			Draws2:	$('#Scores .Score .Draw'),
		}

		xhr.overrideMimeType('application/json');

		LoadScore();
		setInterval("LoadScore()", 1000);

		LoadConfig()
		setInterval("LoadConfig()", 5000);

		setInterval("FadeStartingRateRole()", 5000);
	}

	//--------------------------------------------------------------------------
	// LoadScore
	//--------------------------------------------------------------------------
	function LoadScore() {
		console.log("LoadScore");

		if( !IsPlaying )
		{
			xhr.open('GET', ScoreFilePath+"?dummy="+Date.now(), true);
			xhr.send();
			xhr.onreadystatechange = function(){
				if (xhr.readyState === 4) {
					// 前回の状態を記憶
					if( ScoreFile != undefined )
					{
						OldScoreFile = ScoreFile;
					}
					// 読み込んだ json をパースする
					ScoreFile = JSON.parse(xhr.responseText);
					// 初回はOldScoreFileと同期し、スコアボードを更新する
					if( OldScoreFile == undefined )
					{
						OldScoreFile = ScoreFile;
						SetScore();
					}
					else
					{
						ScoreScrutiny();
					}
				}
			}		
		}
	}

	//--------------------------------------------------------------------------
	// SetScore
	//--------------------------------------------------------------------------
	function SetScore() {
		console.log("SetScore");

		Elements.Wins1.text(ScoreFile.Wins);
		Elements.Wins2.text(ScoreFile.Wins);
		Elements.Loses1.text(ScoreFile.Loses);
		Elements.Loses2.text(ScoreFile.Loses);
		Elements.Draws1.text(ScoreFile.Draws);
		Elements.Draws2.text(ScoreFile.Draws);

		var startingRate = $('#ScoreBoard > .StartingRate');
		var spacer = $('#ScoreBoard > .Spacer');
		if( ScoreFile.IsOpenQueueMode || ScoreFile.IsTankStartingRateEnabled || ScoreFile.IsDamageStartingRateEnabled || ScoreFile.IsSupportStartingRateEnabled )
		{
			startingRate.show();
			spacer.show();
		}
		else
		{
			startingRate.hide();
			spacer.hide();
		}

		var activeStartingRateRole = null;
		if( ScoreFile.IsOpenQueueMode || ScoreFile.IsTankStartingRateEnabled )
		{
			activeStartingRateRole = "Tank";
		}
		else if( ScoreFile.IsDamageStartingRateEnabled )
		{
			activeStartingRateRole = "Damage";
		}
		else if( ScoreFile.IsSupportStartingRateEnabled )
		{
			activeStartingRateRole = "Support";
		}

		var startingRates = {};
		var tankRoleIcon = $('#ScoreBoard > .StartingRate > .RateContainer > .Role.Tank > .RoleIcon');
		if( ScoreFile.IsOpenQueueMode )
		{
			tankRoleIcon.hide();
		}
		else
		{
			tankRoleIcon.show();
		}
		// オープンキューモードの場合はタンクのノードのみを使用
		startingRates["Tank"] = {
			SkillRate: ScoreFile.TankStartingRate,
			IsInPlacement: ScoreFile.IsTankInPlacement,
			IsShow: (ScoreFile.IsOpenQueueMode || ScoreFile.IsTankStartingRateEnabled),
			Opacity: (activeStartingRateRole == "Tank" || ScoreFile.IsOpenQueueMode) ? '1' : '0'
		};
		startingRates["Damage"] = {
			SkillRate: ScoreFile.DamageStartingRate,
			IsInPlacement: ScoreFile.IsDamageInPlacement,
			IsShow: (!ScoreFile.IsOpenQueueMode && ScoreFile.IsDamageStartingRateEnabled),
			Opacity: activeStartingRateRole == "Damage" ? '1' : '0'
		};
		startingRates["Support"] = {
			SkillRate: ScoreFile.SupportStartingRate,
			IsInPlacement: ScoreFile.IsSupportInPlacement,
			IsShow: (!ScoreFile.IsOpenQueueMode && ScoreFile.IsSupportStartingRateEnabled),
			Opacity: activeStartingRateRole == "Support" ? '1' : '0'
		};

		Object.keys(startingRates).forEach(function(key)
		{
			var startingRate = startingRates[key];
			var targetRole = key;
			if( startingRate.IsInPlacement )
			{
				SetStartingRate(-1, targetRole, startingRate.IsShow, startingRate.Opacity);
			}
			else
			{
				SetStartingRate(startingRate.SkillRate, targetRole, startingRate.IsShow, startingRate.Opacity);
			}
		});

		UpdateRateContainerSize();
	}

	//--------------------------------------------------------------------------
	// LoadConfig
	//--------------------------------------------------------------------------
	function LoadConfig()
	{
		console.log("LoadConfig");

		xhr.open('GET', ConfigFilePath+"?dummy="+Date.now(), true);
		xhr.send();
		xhr.onreadystatechange = function(){
			if (xhr.readyState === 4) {
				// 前回の状態を記憶
				if( ConfigFile != undefined )
				{
					OldConfigFile = ConfigFile;
				}
				// 読み込んだ json をパースする
				ConfigFile = JSON.parse(xhr.responseText);
				// 初回はOldScoreFileと同期し、Configを反映する
				if( OldConfigFile == undefined )
				{
					OldConfigFile = ConfigFile;
					SetConfig();
				}
				else
				{
					ConfigScrutiny();
				}
			}
		}		
	}

	//--------------------------------------------------------------------------
	// SetConfig
	//--------------------------------------------------------------------------
	function SetConfig()
	{
		console.log("SetConfig");

		// 名前を反映
		$('#Wins > .Name, #Loses > .Name').text(ConfigFile.Name);

		// ロゴ画像を反映
		$('#Wins > .Logo > img, #Loses > .Logo > img').attr('src', ConfigFile.LogoImageFilePath+"?dummy="+Date.now());

		// メインカラーを反映
		$('#Wins, #Loses, #Draw').css('background', ConfigFile.MainColorHtml);

		// サブカラーを反映
		$('#Transition, #EdgeLeft, #EdgeRight').css('background', ConfigFile.SubColorHtml);

		// フォントカラーを反映
		$('#Wins, #Loses, #Draw').css('color', ConfigFile.FontColorHtml);

		// スコアボードサイズと位置を反映
		var Size = ConfigFile.ScoreBoardSize/100.0;
		var Margin = 4*Size;//vh
		$('#ScoreBoard').css('transform', 'scale('+Size+')')
		$('#ScoreBoard').css('bottom', '');
		$('#ScoreBoard').css('top', '');
		$('#ScoreBoard').css(ConfigFile.ScoreBoardPosition, Margin+'vh');
	}

	//--------------------------------------------------------------------------	
	// ScoreScrutiny
	//--------------------------------------------------------------------------
	function ScoreScrutiny()
	{
		console.log("ScoreScrutiny");

		var UpdateType = undefined;

		if( ScoreFile.Wins != OldScoreFile.Wins )
		{
			if( UpdateType == undefined && ScoreFile.Wins > OldScoreFile.Wins )
			{
				UpdateType = "Win";
			}
			else
			{
				UpdateType = "General";
			}
		}
		if( ScoreFile.Loses != OldScoreFile.Loses )
		{
			if( UpdateType == undefined && ScoreFile.Loses > OldScoreFile.Loses  )
			{
				UpdateType = "Lose";
			}
			else
			{
				UpdateType = "General";
			}
		}
		if( ScoreFile.Draws != OldScoreFile.Draws )
		{
			if( UpdateType == undefined && ScoreFile.Draws > OldScoreFile.Draws )
			{
				UpdateType = "Draw";
			}
			else
			{
				UpdateType = "General";
			}
		}
		if( ScoreFile.IsTankStartingRateEnabled != OldScoreFile.IsTankStartingRateEnabled
		||	ScoreFile.IsDamageStartingRateEnabled != OldScoreFile.IsDamageStartingRateEnabled
		||	ScoreFile.IsSupportStartingRateEnabled != OldScoreFile.IsSupportStartingRateEnabled )
		{
			UpdateType = "General";
		}
		if( ScoreFile.TankStartingRate != OldScoreFile.TankStartingRate
		||	ScoreFile.DamageStartingRate != OldScoreFile.DamageStartingRate
		||	ScoreFile.SupportStartingRate != OldScoreFile.SupportStartingRate )
		{
			UpdateType = "General";
		}
		if( ScoreFile.IsTankInPlacement != OldScoreFile.IsTankInPlacement
		||	ScoreFile.IsDamageInPlacement != OldScoreFile.IsDamageInPlacement
		||	ScoreFile.IsSupportInPlacement != OldScoreFile.IsSupportInPlacement )
		{
			UpdateType = "General";
		}
		if( ScoreFile.IsOpenQueueMode != OldScoreFile.IsOpenQueueMode )
		{
			UpdateType = "General";
		}
		if( !ConfigFile.EnableProduction && UpdateType != undefined )
		{
			UpdateType = "General";
		}

		switch (UpdateType) {
			case "Win":
				Victory();
				break;
			case "Lose":
				Defeat();
				break;
			case "Draw":
				Draw();
				break;
			case "General":
				UpdateScoreBoard();
				break;
		}
	}

	//--------------------------------------------------------------------------
	// ConfigScrutiny
	//--------------------------------------------------------------------------
	function ConfigScrutiny()
	{
		console.log("ConfigScrutiny");

		if( ConfigFile.TimeStamp != OldConfigFile.TimeStamp )
		{
			SetConfig();
		}
	}

	//--------------------------------------------------------------------------
	// Victory
	//--------------------------------------------------------------------------
	function Victory()
	{
		IsPlaying = true;

		$.playSound("./data/wav/wins.wav", ConfigFile.SoundVolume);
		$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
			function(){
				$('#Wins').show();
				$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine');
				$('#EdgeLeft').animate({'left': '0'}, 500);
				$('#EdgeRight').animate({'right': '0'}, 500);
				SetScore();
			}
		);
		Sleep(2500).done(function(){
			$.playSound("./data/wav/transition2.wav", ConfigFile.SoundVolume)
			$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
				function(){
					$('#Wins').hide();
					$('#Scores').show();
					$('#Transition').animate({"margin-left": "-100%"}, 266, 'easeOutSine');
					$('.ScorePanel')
						.animate({'margin-left': '-5%'}, 300)
						.animate({'margin-left': '5%'}, 2500, 'linear')
						.animate({'margin-left': '100%'}, 300, function(){$('.ScorePanel').css('margin-left', '-100%');});
					Sleep(2800).done(function(){
						$.playSound("./data/wav/transition3.wav", ConfigFile.SoundVolume)
						$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
							function(){
								$('#Scores').hide();
								$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine', function(){$('#Transition').css('margin-left', '-100%');});
								$('#EdgeLeft').css('left', '-2vw');
								$('#EdgeRight').css('right', '-2vw');
								IsPlaying = false;
							}
						);
					});
				}
			);
		});
	}

	//--------------------------------------------------------------------------
	// Defeat
	//--------------------------------------------------------------------------
	function Defeat()
	{
		IsPlaying = true;

		$.playSound("./data/wav/loses.wav", ConfigFile.SoundVolume)
		$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
			function(){
				$('#Loses').show();
				$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine');
				$('#EdgeLeft').animate({'left': '0'}, 500);
				$('#EdgeRight').animate({'right': '0'}, 500);
				SetScore();
			}
		);
		Sleep(2500).done(function(){
			$.playSound("./data/wav/transition2.wav", ConfigFile.SoundVolume)
			$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
				function(){
					$('#Loses').hide();
					$('#Scores').show();
					$('#Transition').animate({"margin-left": "-100%"}, 266, 'easeOutSine');
					$('.ScorePanel')
						.animate({'margin-left': '-5%'}, 300)
						.animate({'margin-left': '5%'}, 2500, 'linear')
						.animate({'margin-left': '100%'}, 300, function(){$('.ScorePanel').css('margin-left', '-100%');});
					Sleep(2800).done(function(){
						$.playSound("./data/wav/transition3.wav", ConfigFile.SoundVolume)
						$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
							function(){
								$('#Scores').hide();
								$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine', function(){$('#Transition').css('margin-left', '-100%');});
								$('#EdgeLeft').css('left', '-2vw');
								$('#EdgeRight').css('right', '-2vw');
								IsPlaying = false;
							}
						);
					});
				}
			);
		});
	}

	//--------------------------------------------------------------------------
	// Draw
	//--------------------------------------------------------------------------
	function Draw()
	{
		IsPlaying = true;

		$.playSound("./data/wav/draw.wav", ConfigFile.SoundVolume)
		$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
			function(){
				$('#Draw').show();
				$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine');
				$('#EdgeLeft').animate({'left': '0'}, 500);
				$('#EdgeRight').animate({'right': '0'}, 500);
				SetScore();
			}
		);
		Sleep(2500).done(function(){
			$.playSound("./data/wav/transition2.wav", ConfigFile.SoundVolume)
			$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
				function(){
					$('#Draw').hide();
					$('#Scores').show();
					$('#Transition').animate({"margin-left": "-100%"}, 266, 'easeOutSine');
					$('.ScorePanel')
						.animate({'margin-left': '-5%'}, 300)
						.animate({'margin-left': '5%'}, 2500, 'linear')
						.animate({'margin-left': '100%'}, 300, function(){$('.ScorePanel').css('margin-left', '-100%');});
					Sleep(2800).done(function(){
						$.playSound("./data/wav/transition3.wav", ConfigFile.SoundVolume)
						$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
							function(){
								$('#Scores').hide();
								$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine', function(){$('#Transition').css('margin-left', '-100%');});
								$('#EdgeLeft').css('left', '-2vw');
								$('#EdgeRight').css('right', '-2vw');
								IsPlaying = false;
							}
						);
					});
				}
			);
		});
	}

	//--------------------------------------------------------------------------
	// SetStartingRate
	//--------------------------------------------------------------------------
	function SetStartingRate(sr, role, isShow, opacity)
	{
		var targetRole = $('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role);
		targetRole.animate({'opacity': opacity}, 0);
		if( isShow )
		{
			targetRole.show();
		}
		else
		{
			targetRole.hide();
		}

		$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .sr').text(sr);
		$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .Division').hide();
		
		if( sr == -1 )
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .sr').text("In Placement");
		}
		else if( sr <= 1499 )
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .Division.Bronze').show();
		}
		else if( sr <= 1999 )
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .Division.Silver').show();
		}
		else if( sr <= 2499 )
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .Division.Gold').show();
		}
		else if( sr <= 2999 )
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .Division.Platinum').show();
		}
		else if( sr <= 3499 )
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .Division.Diamond').show();
		}
		else if( sr <= 3999 )
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .Division.Master').show();
		}
		else
		{
			$('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+role+' > .SkillRate > .Division.Grandmaster').show();
		}
	}

	//--------------------------------------------------------------------------
	// UpdateRateContainerSize
	//--------------------------------------------------------------------------
	function UpdateRateContainerSize()
	{
		var rateContainer = $('#ScoreBoard > .StartingRate > .RateContainer');
		var roleElements = rateContainer.children('.Role');

		// 横幅を自動に戻す
		roleElements.each(function(index, element)
		{
			$(element).css('width', 'auto');
		});

		if( ScoreFile.IsOpenQueueMode )
		{
			var tankElement = rateContainer.children('.Role.Tank');
			var newContainerSize = tankElement.outerWidth();
			rateContainer.outerWidth(newContainerSize);
		}
		else
		{
			// 一番大きい要素を割り出す
			var biggestElement = null;
			roleElements.each(function(index, element)
			{
				if( biggestElement == null || $(element).outerWidth() > $(biggestElement).outerWidth() )
				{
					biggestElement = element;
				}
			});

			// すべての要素を一番大きい要素に合わせる
			var newContainerSize = $(biggestElement).outerWidth();
			rateContainer.outerWidth(newContainerSize);
			roleElements.each(function(index, element)
			{
				$(element).outerWidth(newContainerSize);
			});
		}
	}

	//--------------------------------------------------------------------------
	// UpdateScoreBoard
	//--------------------------------------------------------------------------
	function UpdateScoreBoard()
	{
		$('#ScoreBoard')
			.animate({'opacity': '0'}, 300, function(){ SetScore(); })
			.animate({'opacity': '1'}, 300);
	}

	//--------------------------------------------------------------------------
	// FadeStartingRateRole
	//--------------------------------------------------------------------------
	function FadeStartingRateRole()
	{
		if( ScoreFile.IsOpenQueueMode )
		{
			return;
		}

		var fadeTable = [];
		if( ScoreFile.IsTankStartingRateEnabled ){ fadeTable.push("Tank"); }
		if( ScoreFile.IsDamageStartingRateEnabled ){ fadeTable.push("Damage"); }
		if( ScoreFile.IsSupportStartingRateEnabled ){ fadeTable.push("Support"); }
		if( fadeTable.length <= 1 )
		{
			/*
			var role = $('#ScoreBoard > .StartingRate > .RateContainer > .Role.'+fadeTable[0]);
			role.animate({'opacity': '1'}, 1000);
			*/
			return;
		}

		var roles = $('#ScoreBoard > .StartingRate > .RateContainer > .Role');
		var activeElement = null;
		var nextElement = null;
		roles.each(function(index, element)
		{
			if( $(element).css('opacity') == '1' )
			{
				activeElement = element;
				for( var i = index+1; true; i++ )
				{
					if( i == index )
					{
						break;
					}
					if( i >= roles.length )
					{
						i = 0;
					}
					var role = roles[i];
					var roleName = $(role).data('role');
					if( fadeTable.includes(roleName) )
					{
						nextElement = role;
						$(activeElement).animate({'opacity': '0'}, 1000);
						$(nextElement).animate({'opacity': '1'}, 1000);
						return false;
					}
				}
			}
		});
	}
	
	//--------------------------------------------------------------------------
	// Sleep
	//--------------------------------------------------------------------------
	function Sleep(ms)
	{
		// jQueryのDeferredを作成
		var objDef = new $.Deferred;
	
		setTimeout(function () {
			// msミリ秒後に、resolve()を実行し、Promiseを完了
			objDef.resolve(ms);
		}, ms);

		return objDef.promise();
	};