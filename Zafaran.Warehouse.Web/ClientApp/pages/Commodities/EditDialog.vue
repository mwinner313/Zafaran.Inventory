<template>
  <md-card>
    <md-card-header data-background-color="orange">
      <h4>ویرایش</h4>
    </md-card-header>
    <md-card-content>
      <md-field>
        <label>عنوان</label>
        <md-input v-model="editing.title"></md-input>
      </md-field>
      <md-field>
        <label>کد</label>
        <md-input v-model="editing.code"></md-input>
      </md-field>
    </md-card-content>
    <md-card-actions>
      <md-button class="md-primary" @click="save">ویرایش</md-button>
    </md-card-actions>
  </md-card>
</template>

<script>
    export default {
        props:{
          editing:{
            type:Object,
            required:true,
          }
        },
        methods:{
          async save() {
            let res = await this.$http.put('api/commodity',this.editing);
            this.$toaster.success('انجام  شد.');
            this.$emit('edit-done');
          }
        }
    }
</script>

<style scoped>

</style>
