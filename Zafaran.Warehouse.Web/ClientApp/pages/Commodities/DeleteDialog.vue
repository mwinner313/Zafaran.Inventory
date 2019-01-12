<template>
  <div>
    <md-card >
      <md-card-header  data-background-color="orange">
        <h4>از حذف این مورد مطمعن هستید؟</h4>
      </md-card-header>
      <md-card-content>
        عنوان      :
        <br>
        <p>{{deleting.title}} </p>
        کد  :
        <br>

        <p>{{deleting.code}}  </p>

        شناسه   :
        <br>
        <p>{{deleting.id}} </p>
      </md-card-content>
      <md-card-actions>
        <md-button @click.prevent="cancel" > بستن</md-button>
        <md-button @click.prevent="remove" class="md-danger"> بلی</md-button>
      </md-card-actions>
    </md-card>
  </div>
</template>

<script>
  export default {
    props: {
      deleting: {
        type: Object,
        required: true
      }
    },
    methods: {
      cancel(){
        this.$emit('delete-done');
      },
      async remove() {
        let res = await this.$http.delete('api/commodity/' +this.deleting.id);
        if(res.body.succeed){
          this.$emit('delete-done');
          this.$toaster.success('انجام  شد.')
        }else{
          this.$swal({
            type: 'error',
            title: 'خطا ....',
            text: res.body.message,
            confirmButtonText: 'باشه !',
          })
        }
      }
    }
  }
</script>

<style>

</style>
