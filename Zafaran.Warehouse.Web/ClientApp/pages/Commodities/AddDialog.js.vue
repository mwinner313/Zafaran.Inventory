<template>
  <md-card>
    <md-card-header data-background-color="orange">
      <h4>ثبت محصول جدید</h4>
    </md-card-header>
    <md-card-content>
      <md-field>
        <label>عنوان</label>
        <md-input v-model="item.title"></md-input>
      </md-field>
      <md-field>
        <label>کد</label>
        <md-input v-model="item.code"></md-input>
      </md-field>
      <md-field>
        <label>واحد اندازه گیری</label>
        <md-select v-model="item.unitId" >
          <md-option value="1">گرم</md-option>
          <md-option value="2">گرم</md-option>
          <md-option value="2">گرم</md-option>
        </md-select>
      </md-field>
    </md-card-content>
    <md-card-actions>
      <md-button class="md-primary" @click="save">ثبت</md-button>
    </md-card-actions>
  </md-card>
</template>

<script>
  export default {
    data(){
      return{
        item:{
          title:'',
          unitId:0,
          code:''
        }
      }
    },
    methods:{
      async save() {
        let res = await this.$http.post('api/commodity',this.item);
        this.$toaster.success('انجام  شد.');
        this.$emit('add-done');
      }
    }
  }
</script>

<style scoped>

</style>
