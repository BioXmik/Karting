mergeInto(LibraryManager.library, {

	ShowAdv : function(){
		ysdk.adv.showFullscreenAdv({
			callbacks: {
			onClose: function(wasShown) {
				// some action after close
        },
			onError: function(error) {
				// some action on error
			}
			}
			})
	},
	
	ShowAdvRewarded : function(){
		ysdk.adv.showRewardedVideo({
			callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
		  myGameInstance.SendMessage("MenuManager", "BalanceAdd");
        },
        onClose: () => {
          console.log('Video ad closed.');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
	},

	});