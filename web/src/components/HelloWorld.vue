<template>
  <div>
    <div class="top-view">
      <el-menu
        :default-active="activeIndex2"
        class="el-menu-demo"
        mode="horizontal"
        @select="handleSelect"
        background-color="#545c64"
        text-color="#fff"
        active-text-color="#ffd04b"
      >
        <el-menu-item class="menu-item" index="1">首页</el-menu-item>
        <el-submenu class="menu-item" index="2">
          <template slot="title">我的工作台</template>
          <el-menu-item index="2-1">选项1</el-menu-item>
          <el-menu-item index="2-2">选项2</el-menu-item>
          <el-menu-item index="2-3">选项3</el-menu-item>
          <el-submenu index="2-4">
            <template slot="title">选项4</template>
            <el-menu-item index="2-4-1">选项1</el-menu-item>
            <el-menu-item index="2-4-2">选项2</el-menu-item>
            <el-menu-item index="2-4-3">选项3</el-menu-item>
          </el-submenu>
        </el-submenu>
        <el-menu-item class="menu-item" index="3">消息中心</el-menu-item>
        <el-menu-item class="menu-item" index="4">关于我们</el-menu-item>
        <el-menu-item class="menu-item" index="5" @click="openWindows()">
          <el-avatar src="https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png"></el-avatar>
        </el-menu-item>
      </el-menu>
    </div>
    <div class="image-view">
       <img src="../assets/logo.png">
    </div>
    <div>{{userName}}</div>
        <div>{{token}}</div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userName: "",
      token: "",
      url: "http://localhost:8080/#/UserInfo",
      activeIndex: "1",
      activeIndex2: "1"
    };
  },
  mounted: function() {
    console.log(this.$route.query);
    
    this.userName =
      this.$route.query.userName === undefined
        ? "zhubingjian"
        : this.$route.query.userName;
    this.token =
      this.$route.query.token === undefined ? "token" : this.$route.query.token;
  },
  methods: {
    openWindows() {
      newpage(this.url);
    },
    handleSelect(key, keyPath) {
      console.log(key, keyPath);
    }
  }
};
</script>

<style scoped>
.top-view {
  position: absolute;
  top: 0px;
  width: 99%;
}
.menu-item{
  width: 20%;
}
.image-view{
  padding-top: 10%;
}
</style>
