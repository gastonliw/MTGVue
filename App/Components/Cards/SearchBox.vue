<template>
  <div class="row">      
      <div class="input-group">
        <div class="input-group-prepend">
          <span class="input-group-text" id="cardname">Card name:</span>          
        </div>
        <input @keyup.enter="searchCard" v-model="searchText" type="text" class="form-control" id="cardname" aria-describedby="cardname">
        <div class="input-group-append">
          <span class="input-group-btn">
            <button v-on:click="searchCard" class="btn btn-outline-secondary" type="button">
              <div style="font-size:1.5em;">
                <i class="fas fa-search"></i>
              </div>
            </button>
          </span>
          <span class="input-group-btn">
            <button v-on:click="getRandomCard" class="btn btn-outline-secondary" type="button">Random</button>
          </span>
        </div>      
      </div>

  </div>
</template>

<script>
  import ApiMethods from '../../Api/ApiMethods'
  import $ from 'jquery'

  export default {
    data: function () {
    return {
        searchText: '',        
      }
    },
    methods: {            
            getRandomCard: function(){
              this.searchText = '';
              ApiMethods
                .getApi('/api/Cards/Random')
                .then((data) => {                                        
                    this.$emit('selectCard', data);
                });
            },
            searchCard: function(){
              if(this.searchText!='')
              {
                ApiMethods
                  .getApi('/api/Cards/ByName/' + this.searchText)
                  .then((data) => {
                    if(data==null)
                      alert('Card not found');
                    this.$emit('selectCard', data);
                  });
              }else{
                this.searchText='';                
                this.$emit('selectCard', null);
              }
            }
        },
  }
</script>
