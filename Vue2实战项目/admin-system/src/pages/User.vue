<!--
  功能：功能描述
  作者：albertzhao
  邮箱：szdxzhy@outlook.com
  时间：2023年05月20日 10:50:28
  版本：v1.0
  修改记录：
  修改内容：
  修改人员：
  修改时间：
-->
<template>
  <div class="user">
    <!-- 各种编辑按钮 -->
    <div class="user-header">
      <el-button type="primary" @click="addDialog = true">新增</el-button>
      <el-button type="success" @click="dialogVisible = true">编辑</el-button>
      <el-button type="danger" @click="delDialog">删除</el-button>
    </div>
    <!-- Form -->
    <div class="user-form">
      <el-table ref="multipleTable" :data="userTableData" tooltip-effect="dark" style="width: 100%" @selection-change="handleSelectionChange">
        <el-table-column type="selection" width="55">
        </el-table-column>
        <el-table-column label="日期" width="120">
          <template slot-scope="scope">{{ scope.row.date }}</template>
        </el-table-column>
        <el-table-column prop="name" label="姓名" width="120">
        </el-table-column>
        <el-table-column prop="address" label="地址" show-overflow-tooltip>
        </el-table-column>
      </el-table>
    </div>

    <!-- 弹出框组件 -->
    <el-dialog title="提示" :visible.sync="addDialog" width="50%">
      <el-form ref="userForm" :inline="true" :model="userForm" label-width="80px">
        <el-form-item label="姓名">
          <el-input v-model="userForm.name"></el-input>
        </el-form-item>
        <el-form-item label="地址">
          <el-input v-model="userForm.address"></el-input>
        </el-form-item>
        <!-- <el-form-item label="活动区域">
          <el-select v-model="form.region" placeholder="请选择活动区域">
            <el-option label="区域一" value="shanghai"></el-option>
            <el-option label="区域二" value="beijing"></el-option>
          </el-select>
        </el-form-item> -->
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="addDialog = false">取 消</el-button>
        <el-button type="primary" @click="addDialog = false">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
import { getData } from "@/api/index.js";

export default {
  // 组件名称
  // eslint-disable-next-line vue/multi-word-component-names
  name: "User",
  // 组件参数 接收来自父组件的数据
  props: {},
  // 局部注册的组件
  components: {},
  // 组件状态值
  data() {
    return {
      addDialog: false,
      userTableData: [],
      userForm: {
        name: "",
        address: "",
      },
    };
  },
  // 计算属性
  computed: {},
  // 侦听器
  watch: {},
  // 组件方法
  methods: {
    delDialog() {
      // 删除选中行
      const _selectData = this.$refs.multipleTable.selection;
      console.log(_selectData);
    },
  },

  mounted() {
    getData().then((data) => {
      const { userTableData } = data.data.data;
      this.userTableData = userTableData;
      console.log(userTableData);
    });
  },
};
</script> 

<!-- Add "scoped" attribute to limit CSS to this component only -->
<!--使用了scoped属性之后，父组件的style样式将不会渗透到子组件中，-->
<!--然而子组件的根节点元素会同时被设置了scoped的父css样式和设置了scoped的子css样式影响，-->
<!--这么设计的目的是父组件可以对子组件根元素进行布局。-->
<style scoped lang="less">
.user {
  .user-header {
    display: flex;
    justify-content: flex-end;
    margin-bottom: 10px;

    .el-button {
      margin-left: 10px;
      color: white;
    }
  }
}
</style>
