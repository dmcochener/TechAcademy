
	var totalCost = 0;
	var sizeCost = 0;
	var crustCost = 0;
	var meatCost = 0;
	var cheeseCost = 0;
	var veggieCost = 0;
	
	
	var getSize = function(){
		var sizeArray = document.getElementsByName("size");
		for (var i=0; i< sizeArray.length; i++){ 
			if (sizeArray[i].checked) {
				var selectedSize = sizeArray[i].value;
			}
		}
		console.log(selectedSize);
		
		if (selectedSize == "personal"){
			sizeCost = 6;
		}
		else if (selectedSize == "medium"){
			sizeCost = 10;
		}
		else if (selectedSize == "large") {
			sizeCost = 14;
		}
		else if (selectedSize == "xlarge") {
			sizeCost = 16;
		} 
		console.log("Size Cost is " + sizeCost);
		pizzaCost();
		var sizeReceipt = document.getElementsByClassName("receipt-size")
		if (selectedSize !== undefined){
			sizeReceipt[0].innerHTML = "Pizza size: " + selectedSize;
			sizeReceipt[1].innerHTML = "$ " + sizeCost + ".00";
			}
	}

	
	var getCrust = function() {
		var crustArray = document.getElementsByName("crust");
		for (var r=0; r<crustArray.length; r++) {
			if (crustArray[r].checked) {
				var selectedCrust = crustArray[r].value;
			
			}
		}
		console.log(selectedCrust);
		
		if (selectedCrust == "stuffed") {
			crustCost = 3; 
		}
		else {
			crustCost = 0;
		}
		console.log("Crust Cost is " + crustCost);
		pizzaCost();
		var crustReceipt = document.getElementsByClassName("receipt-crust")
		crustReceipt[0].innerHTML = "Type of crust: " + selectedCrust;
		crustReceipt[1].innerHTML = "$ " + crustCost + ".00";
	
	}
	
	var getSauce = function() {
		var sauceArray = document.getElementsByName("sauce");
		for (var s=0; s<sauceArray.length; s++) {
			if (sauceArray[s].checked) {
				var selectedSauce = sauceArray[s].value;
			}
		}
		console.log(selectedSauce);
		var sauceReceipt = document.getElementsByClassName("receipt-sauce")
		sauceReceipt[0].innerHTML = "Type of sauce: " + selectedSauce;
	}
	
	var getMeat = function() {
		var meatTotal = 0;
		var selectedMeat = [];
		var meatArray = document.getElementsByName("meat");
		for (var m = 0; m < meatArray.length; m++) {
			if (meatArray[m].checked) {
				selectedMeat.push(meatArray[m].value);			
			}
		}
		console.log(selectedMeat);
		
		var meatCount = selectedMeat.length;
			if (meatCount >= 2) {
				meatCost = (meatCount - 1);
			} 	
			else {
				meatCost = 0;
			}
		console.log("Meat cost is " + meatCost);
		pizzaCost();
		var meatReceipt = document.getElementsByClassName("receipt-meat")
				if (meatCount == 0) {
				meatReceipt[0].innerHTML = "No meat toppings selected";
			}
			else if (meatCount == 1) {
				meatReceipt[0].innerHTML = "Meat toppings: " + selectedMeat;
			}
			else {
				var meatText = "";
				for (var y = 0; y < meatCount; y++) {
					meatText += selectedMeat[y] + ", ";
				meatReceipt[0].innerHTML = "Meat toppings: " + meatText;
			}}
		meatReceipt[1].innerHTML = "$ " + meatCost + ".00";
	}	
	
	var getCheese = function() {
		var cheeseArray = document.getElementsByName("cheese");
		for (var h = 0; h < cheeseArray.length; h++) {
			if (cheeseArray[h].checked) {
				var selectedCheese = cheeseArray[h].value;
				
			}
		}
		console.log(selectedCheese);
		
		if (selectedCheese == "extra") {
			cheeseCost = 3;
		}
		else {
			cheeseCost = 0;
		}
		console.log("Cheese cost is " + cheeseCost);
		pizzaCost();
		var cheeseReceipt = document.getElementsByClassName("receipt-cheese")
		cheeseReceipt[0].innerHTML = "Amount of cheese: " + selectedCheese;
		cheeseReceipt[1].innerHTML = "$ " + cheeseCost + ".00";
	}

	var getVeggie = function() {
		var veggieTotal = 0;
		var selectedVeggie = [];
		var veggieArray = document.getElementsByName("veggie");
		for (var v = 0; v < veggieArray.length; v++) {
			if (veggieArray[v].checked) {
				selectedVeggie.push(veggieArray[v].value);
			}
			
		}
		console.log(selectedVeggie);
		
		var veggieCount = selectedVeggie.length;
			if (veggieCount >= 2) {
				veggieCost = (veggieCount - 1);
			}
			else {
				veggieCost = 0;
			}
		console.log("Veggie cost is " + veggieCost);
		pizzaCost();
		var veggieReceipt = document.getElementsByClassName("receipt-veggie")
			if (veggieCount == 0) {
				veggieReceipt[0].innerHTML = "No vegetable toppings selected";
			}
			else if (veggieCount == 1) {
				veggieReceipt[0].innerHTML = "Vegetable toppings: " + selectedVeggie;
			}
			else {
				var veggieText = "";
				for (var x = 0; x < veggieCount; x++) {
					veggieText += selectedVeggie[x] + ", ";
				veggieReceipt[0].innerHTML = "Vegetable toppings: " + veggieText;
			}}
		veggieReceipt[1].innerHTML = "$ " + veggieCost + ".00";
	}
	
	var pizzaCost = function(){
		totalCost = sizeCost + crustCost + meatCost + cheeseCost + veggieCost;
		document.getElementById("receipt-total").innerHTML = "$ " + totalCost + ".00";
		console.log("Total Cost is " + totalCost);
	}
	
	var getAll = function(){
		getSize(); 
		getSauce(); 
		getCrust(); 
		getMeat(); 
		getCheese(); 
		getVeggie(); 
		pizzaCost();
	}
	
	var getPizza = function() {
		var modalText = "Hello, please place an order";
		var Title = "Dear "
		if (sizeCost == 0) {
			modalText = "Your order is not complete. Please complete all required sections before submitting";
		}
		
		else {
			modalText = "Thank you for your order!";
		}
		var input = $("#CustomerName").val();
		console.log(input);
		document.getElementById("modalTitle").innerHTML= "Dear " + input;
		document.getElementById("modalMessage").innerHTML= modalText;
		console.log(totalCost);	
	}	

