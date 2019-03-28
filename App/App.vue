<!-- Any future bootstrap-specific customization should be declared before this import -->
<style lang="scss">
	@import '../node_modules/bootstrap/scss/bootstrap.scss';
</style>
<template>
	<div class="container">		
		<div class="card col-xs-4 col-lg-8 col-md-8 offset-md-2 mt-3">
			<SearchBox></SearchBox>
			<Cards></Cards>
		</div>
	</div>
</template>

<script>
	import Cards from './Components/Cards/CardTable.vue';	
	import SearchBox from './Components/Cards/SearchBox.vue';		

    export default {
		components:{
			Cards,			
			SearchBox
		},		
	};   
    
</script>
