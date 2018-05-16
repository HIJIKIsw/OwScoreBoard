//------------------------------------------------------------------------------
// main.js
//------------------------------------------------------------------------------

	var xhr = new XMLHttpRequest();
	var oldFile;
	var file;
	var Elements;
	var IsPlaying = false;
	var IsInitialized = false;

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
		setInterval("DataLoad()", 1000);
		//setTimeout("AntiLoadMiss()", 3000)	//一部環境上(例えばOBS)でのロードミスを防ぐ

		// テストコード
		Sleep(500).done(function(){
			//Draw();
		})

		Sleep(8000).done(function(){
		//	Defeat();
		})
	}

	//--------------------------------------------------------------------------
	// DataLoad
	//--------------------------------------------------------------------------
	function DataLoad() {
		console.log("DataLoad");

		if( !IsPlaying )
		{
			console.log("Loading...");
			xhr.open('GET', "./data.json?dummy="+Date.now(), true);
			xhr.send();
			xhr.onreadystatechange = function(){
				if (xhr.readyState === 4) {
					// 前回の状態を記憶
					if( file != undefined )
					{
						oldFile = file;
					}
					// 読み込んだ json をパースする
					file = JSON.parse(xhr.responseText);
					// 初回のみ同期する
					if( oldFile == undefined )
					{
						oldFile = file;
					}
					// 初回はスコアボードを更新
					if( !IsInitialized )
					{
						IsInitialized = true;
						UpdateScoreBoard();
					}
					DataScrutiny();
				}
			}		
		}
	}

	//--------------------------------------------------------------------------
	// DataSet
	//--------------------------------------------------------------------------
	function DataSet() {
		console.log("DataSet");

		Elements.Wins1.text(file.Wins);
		Elements.Wins2.text(file.Wins);
		Elements.Loses1.text(file.Loses);
		Elements.Loses2.text(file.Loses);
		Elements.Draws1.text(file.Draws);
		Elements.Draws2.text(file.Draws);

		SetStartingRate(file.StartingRate);
	}

	//--------------------------------------------------------------------------	
	// DataScrutiny
	//--------------------------------------------------------------------------
	function DataScrutiny()
	{
		console.log("DataScrutiny");

		var UpdateType = undefined;
		var IsRateUpdated = false;

		if( file.Wins != oldFile.Wins )
		{
			if( UpdateType == undefined && file.Wins > oldFile.Wins )
			{
				UpdateType = "Win";
			}
			else
			{
				UpdateType = "General";
			}
		}
		if( file.Loses != oldFile.Loses )
		{
			if( UpdateType == undefined && file.Loses > oldFile.Loses  )
			{
				UpdateType = "Lose";
			}
			else
			{
				UpdateType = "General";
			}
		}
		if( file.Draws != oldFile.Draws )
		{
			if( UpdateType == undefined && file.Draws > oldFile.Draws )
			{
				UpdateType = "Draw";
			}
			else
			{
				UpdateType = "General";
			}
		}
		if( file.StartingRate != oldFile.StartingRate ){ IsRateUpdated = true; }

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

		if( IsRateUpdated )
		{
			UpdateScoreBoard();
		}
	}

	//--------------------------------------------------------------------------
	// Victory
	//--------------------------------------------------------------------------
	function Victory()
	{
		IsPlaying = true;

		$.playSound("./data/wav/wins.wav")
		$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
			function(){
				$('#Wins').show();
				$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine');
				$('#EdgeLeft').animate({'left': '0'}, 500);
				$('#EdgeRight').animate({'right': '0'}, 500);
				DataSet();
			}
		);
		Sleep(2500).done(function(){
			$.playSound("./data/wav/transition2.wav")
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
						$.playSound("./data/wav/transition3.wav")
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

		$.playSound("./data/wav/loses.wav")
		$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
			function(){
				$('#Loses').show();
				$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine');
				$('#EdgeLeft').animate({'left': '0'}, 500);
				$('#EdgeRight').animate({'right': '0'}, 500);
				DataSet();
			}
		);
		Sleep(2500).done(function(){
			$.playSound("./data/wav/transition2.wav")
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
						$.playSound("./data/wav/transition3.wav")
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

		$.playSound("./data/wav/draw.wav")
		$('#Transition').show().animate({"margin-left": "0"}, 200, 'easeInSine',
			function(){
				$('#Draw').show();
				$('#Transition').animate({"margin-left": "100%"}, 266, 'easeOutSine');
				$('#EdgeLeft').animate({'left': '0'}, 500);
				$('#EdgeRight').animate({'right': '0'}, 500);
				DataSet();
			}
		);
		Sleep(2500).done(function(){
			$.playSound("./data/wav/transition2.wav")
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
						$.playSound("./data/wav/transition3.wav")
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
	function SetStartingRate(sr)
	{
		$('#ScoreBoard > .StartingRate > .Rate > .sr').text(sr);
		$('#ScoreBoard > .StartingRate > .Rate > .Division').hide();
		
		if( sr <= 1499 )
		{
			$('#ScoreBoard > .StartingRate > .Rate > .Division.Bronze').show();
		}
		else if( sr <= 1999 )
		{
			$('#ScoreBoard > .StartingRate > .Rate > .Division.Silver').show();
		}
		else if( sr <= 2499 )
		{
			$('#ScoreBoard > .StartingRate > .Rate > .Division.Gold').show();
		}
		else if( sr <= 2999 )
		{
			$('#ScoreBoard > .StartingRate > .Rate > .Division.Platinum').show();
		}
		else if( sr <= 3499 )
		{
			$('#ScoreBoard > .StartingRate > .Rate > .Division.Diamond').show();
		}
		else if( sr <= 3999 )
		{
			$('#ScoreBoard > .StartingRate > .Rate > .Division.Master').show();
		}
		else
		{
			$('#ScoreBoard > .StartingRate > .Rate > .Division.Grandmaster').show();
		}
	}

	//--------------------------------------------------------------------------
	// UpdateScoreBoard
	//--------------------------------------------------------------------------
	function UpdateScoreBoard()
	{
		$('#ScoreBoard')
			.animate({'bottom': '-15vh'}, 300, function(){ DataSet(); })
			.animate({'bottom': '4vh'}, 300);
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