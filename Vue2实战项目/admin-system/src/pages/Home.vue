<!-- eslint-disable vue/multi-word-component-names -->
<!--
  功能：功能描述
  作者：albertzhao
  邮箱：szdxzhy@outlook.com
  时间：2023年05月20日 10:49:55
  版本：v1.0
  修改记录：
  修改内容：
  修改人员：
  修改时间：
-->
<template>
  <div>
    <el-row>
      <el-col :span="8">
        <div class="grid-content bg-purple">
          <el-card class="box-card">
            <div class="user">
              <img src="../assets/logo.png" alt="" />
              <div class="user-info">
                <p class="name">admin</p>
                <p class="access">超级管理员</p>
              </div>
            </div>
            <div class="login-info">
              <p>上次登录时间：2021-05-20 10:49:55</p>
              <p>上次登录IP：10.168.196.23 </p>
            </div>
          </el-card>
          <!-- 下方表格 card -->
          <el-card class="box-card card-bottom">
            <el-table :data="tableData" style="width: 100%">
              <el-table-column prop="name" label="手机名称"></el-table-column>
              <el-table-column prop="todayBuy" label="日销量"></el-table-column>
              <el-table-column prop="monthBuy" label="月销量"></el-table-column>
              <el-table-column prop="totalBuy" label="总销量"></el-table-column>
            </el-table>
          </el-card>

        </div>
      </el-col>
      <el-col :span="16">
        <div class="count-data">
          <!-- 订单图 -->
          <el-card v-for="item in countData" :key="item.name" :body-style="{
            display:'flex','align-items':'center','padding':'0px'
          }">
            <i class="icon" :class="`el-icon-${item.icon}`" :style="{background:item.color}"></i>
            <div class="count-info">
              <p class="count-value">$ {{ item.value }}</p>
              <p class="count-name">{{ item.name }}</p>
            </div>
          </el-card>
        </div>
        <!-- 曲线图 -->
        <div class="line">
          <el-card class="box-card" style="height:280px">
            <div ref="echart1" style="height:280px"></div>
          </el-card>
        </div>

        <!-- 折线图 -->
        <div class="graph line">
          <el-card style="height:260px">fdsfad</el-card>
          <el-card style="height:260px">fafda</el-card>
        </div>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import { getData } from "@/api/index.js";
import * as echarts from "echarts";

export default {
  // 组件名称
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Home",
  // 组件参数 接收来自父组件的数据
  props: {},
  // 局部注册的组件
  components: {},
  // 组件状态值
  data() {
    return {
      tableData: [],
      countData: [
        {
          name: "今日支付订单",
          value: 1234,
          icon: "success",
          color: "#2ec7c9",
        },
        {
          name: "今日收藏订单",
          value: 210,
          icon: "star-on",
          color: "#ffb980",
        },
        {
          name: "今日未支付订单",
          value: 1234,
          icon: "s-goods",
          color: "#5ab1ef",
        },
        {
          name: "本月支付订单",
          value: 1234,
          icon: "success",
          color: "#2ec7c9",
        },
        {
          name: "本月收藏订单",
          value: 210,
          icon: "star-on",
          color: "#ffb980",
        },
        {
          name: "本月未支付订单",
          value: 1234,
          icon: "s-goods",
          color: "#5ab1ef",
        },
      ],
      orderData: [],
    };
  },
  // 计算属性
  computed: {},
  // 侦听器
  watch: {},
  // 组件方法
  methods: {},
  // 以下是生命周期钩子   注：没用到的钩子请自行删除
  /**
   * 在实例初始化之后，组件属性计算之前，如data属性等
   */
  beforeCreate() {},
  /**
   * 组件实例创建完成，属性已绑定，但DOM还未生成，$ el属性还不存在
   */
  created() {},
  /**
   * 在挂载开始之前被调用：相关的 render 函数首次被调用。
   */
  beforeMount() {},
  /**
   * el 被新创建的 vm.$ el 替换，并挂载到实例上去之后调用该钩子。
   * 如果 root 实例挂载了一个文档内元素，当 mounted 被调用时 vm.$ el 也在文档内。
   */
  mounted() {
    getData().then((data) => {
      const { tableData, orderData } = data.data.data;
      this.tableData = tableData;
      this.orderData = orderData;

      // this.orderData.data.forEach(function (item) {
      //   console.log(item[key]);
      //   data2.push(item[key]);
      // });

      //取出 this.orderData.data 中的 value 值
      // Object.keys(this.orderData.data[0]).map(return key)
      var testArr = Object.keys(this.orderData.data[0]).map((obj) => {
        return obj.key;
      });
      console.log(testArr);
    });

    // 挂载 echarts 图标
    var lineEchart = echarts.init(this.$refs.echart1);
    lineEchart.setOption({
      title: {
        text: "销量",
      },
      // 提示框组件
      tooptip: {},
      // 图例
      legend: {
        data: Object.keys(this.orderData.data[0]),
      },
      // x轴
      xAxis: {
        data: Object.keys(this.orderData.data[0]),
      },
      // y轴
      yAxis: {},
      // 数据
      series: [
        {
          name: "销量",
          type: "bar",
          data: Object.keys(this.orderData.data[0]).map(function (key) {
            return {
              name: key,
              data: this.orderData.data.reduce(function (data, item) {
                data.push(item[key]);
                return data;
              }, []),
            };
          }),
        },
      ],
    });
  },
  /**
   * 数据更新时调用，发生在虚拟 DOM 重新渲染和打补丁之前。
   * 你可以在这个钩子中进一步地更改状态，这不会触发附加的重渲染过程。
   */
  beforeUpdate() {},
  /**
   * 由于数据更改导致的虚拟 DOM 重新渲染和打补丁，在这之后会调用该钩子。
   * 当这个钩子被调用时，组件 DOM 已经更新，所以你现在可以执行依赖于 DOM 的操作。
   */
  updated() {},
  /**
   * keep-alive 组件激活时调用。 仅针对keep-alive 组件有效
   */
  activated() {},
  /**
   * keep-alive 组件停用时调用。 仅针对keep-alive 组件有效
   */
  deactivated() {},
  /**
   * 实例销毁之前调用。在这一步，实例仍然完全可用。
   */
  beforeDestroy() {},
  /**
   * Vue 实例销毁后调用。调用后，Vue 实例指示的所有东西都会解绑定，
   * 所有的事件监听器会被移除，所有的子实例也会被销毁。
   */
  destroyed() {},
};
</script> 

<!-- Add "scoped" attribute to limit CSS to this component only -->
<!--使用了scoped属性之后，父组件的style样式将不会渗透到子组件中，-->
<!--然而子组件的根节点元素会同时被设置了scoped的父css样式和设置了scoped的子css样式影响，-->
<!--这么设计的目的是父组件可以对子组件根元素进行布局。-->
<style scoped lang="less">
.user {
  padding-bottom: 20px;
  margin-bottom: 20px;
  border-bottom: 1px solid #eee;
  // flex 左右分布
  display: flex;
  // 让 flex 布局中的内容垂直居中
  align-items: center;
  img {
    width: 150px;
    height: 150px;
    border-radius: 50%;
    margin-right: 30px;
  }
  .user-info {
    .name {
      font-size: 30px;
      font-weight: bold;
      margin-bottom: 16px;
    }
    .access {
      font-size: 16px;
      color: #999;
    }
  }
}

.card-bottom {
  margin-top: 20px;
  height: 500px;
}

.icon {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 80px;
  height: 80px;
  font-size: 40px;
  text-align: center;
  list-style: 80px;
  color: #fff;
}

.count-data {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  margin-left: 10px;
  .el-card {
    width: 32%;
    margin-bottom: 20px;
    padding-left: 8px;
    .count-info {
      display: flex;
      flex-direction: column;
      justify-content: center;
      margin-left: 15px;
      .count-value {
        font-size: 30px;
        font-weight: bold;
        margin-bottom: 1px;
        // 让文字居中，且高度为30px
        height: 30px;
        line-height: 30px;
      }

      .count-name {
        font-size: 14px;
        color: #999;
        text-align: center;
        padding-top: 2px;
      }
    }
  }
}

.line {
  margin-left: 10px;
}

.graph {
  display: flex;
  justify-content: space-between;
  margin-top: 20px;

  .el-card {
    width: 48%;
  }
}
</style>
