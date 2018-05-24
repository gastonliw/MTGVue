<!-- Any future bootstrap-specific customization should be declared before this import -->
<style lang="scss">
	@import '../node_modules/bootstrap/scss/bootstrap.scss';
</style>
<template>
	<div class="container">		
		<div class="card col-xs-4 col-lg-7 col-md-4 offset-md-3 mt-3">
			<SearchBox></SearchBox>
			<Card></Card>
		</div>
	</div>
</template>

<script>
	import Card from './Components/Cards/Card.vue';
	import SearchBox from './Components/Cards/SearchBox.vue';		

    export default {
		components:{
			Card,
			SearchBox
		},		
	};   
    
</script>
