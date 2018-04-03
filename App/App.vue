<template>
	<div class="container">
		<div class="card col-xs-4 col-lg-6 col-md-4 offset-md-2 mt-3">
			<SearchBox @selectCard="setCard"></SearchBox>
			<Card :card="CardSet"></Card>
		</div>
	</div>
</template>

<script>

	import Card from './Components/Cards/Card.vue';
	import SearchBox from './Components/Cards/SearchBox.vue';	

	//this.getRandomCard()

    export default {
		components:{
			Card,
			SearchBox
		},
		data(){
            return{
				CardSet: null
            };
        },
		methods: {
            setCard: function (selectedCard){                
                this.CardSet = selectedCard;
            }
		},
	};   
    
</script>
