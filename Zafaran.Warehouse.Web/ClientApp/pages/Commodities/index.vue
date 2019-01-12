<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item md-medium-size-100 md-size-50">
        <md-card>
          <md-card-header data-background-color="green">
            <md-button @click="addDialogOpen=true" class="md-btn-fab md-fab md-primary md-card-header-btn">
              <md-icon>add</md-icon>
            </md-button>
            <h4>لیست محصولات</h4>

            <input v-model="searchTerm" @keyup="loadDataWithThrottle" type="text" class="header-input"
                   placeholder="جستجو (عنوان یا کد محصول)"/>
          </md-card-header>

          <md-card-content>
            <md-table v-model="list">
              <md-table-row slot="md-table-row" slot-scope="{ item }">
                <md-table-cell md-numeric md-label="شناسه">{{ item.id }}</md-table-cell>
                <md-table-cell md-label="نام محصول">{{ item.title }}</md-table-cell>
                <md-table-cell md-label="کد محصول">{{ item.code }}</md-table-cell>
                <md-table-cell md-label="واحد">{{ item.unitTitle }}</md-table-cell>
                <md-table-cell md-label="عملیات">
                  <md-button @click="setEditing(item)" :class="[editing===item? '':'md-simple','md-primary']">
                    <md-icon>edit</md-icon>
                    <md-tooltip md-direction="top">ویرایش</md-tooltip>
                  </md-button>
                  <md-button @click="setDeleting(item)" :class="[deleting===item? '':'md-simple','md-danger']">
                    <md-icon>delete</md-icon>
                    <md-tooltip md-direction="top">حذف</md-tooltip>
                  </md-button>
                </md-table-cell>
              </md-table-row>
            </md-table>
          </md-card-content>
        </md-card>
      </div>
      <div class="md-layout-item md-medium-size-100 md-size-50">
        <edit-dialog :editing="editing" @edit-done="loadData" v-if="editing"></edit-dialog>
        <delete-dialog :deleting="deleting" @delete-done="loadData" v-if="deleting"></delete-dialog>
        <add-dialog @add-done="loadData" v-if="addDialogOpen"></add-dialog>
      </div>
    </div>
  </div>
</template>

<script>
  import EditDialog from './EditDialog'
  import AddDialog from './AddDialog.js'
  import DeleteDialog from './DeleteDialog'
  import _ from 'lodash';

  export default {
    components: {
      EditDialog,
      AddDialog,
      DeleteDialog
    },
    data() {
      return {
        editing: null,
        deleting: null,
        list: [],
        searchTerm: '',
        addDialogOpen: false
      }
    },
    methods: {
      loadData: async function () {
        this.editing = null;
        this.deleting = null;
        this.addDialogOpen = false;
        this.list = (await this.$http.get('api/commodity', {
          params: {
            searchTerm: this.searchTerm
          }
        })).body
      }
      ,
      setEditing(item) {
        this.editing = item;
        this.deleting = null;
      },
      setDeleting(item) {
        this.deleting = item;
        this.editing = null;
      }
    },
    created() {
      this.loadDataWithThrottle = _.debounce(() => this.loadData(), 500)
    },
    beforeRouteEnter(to, from, next) {
      next(function (vm) {
        vm.loadData();

      })
    }
  }
</script>
<style>
  .header-input {
    width: 100%;
    border: 0px;
    border-radius: 2px;
    padding: 8px;
    box-shadow: 1px 4px 12px -5px;
  }
</style>
