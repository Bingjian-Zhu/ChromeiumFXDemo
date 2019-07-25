<template>
  <el-form
    :model="ruleForm"
    status-icon
    ref="ruleForm"
    width="350px"
    label-width="100px"
    class="login-from"
  >
    <el-form-item label="用户名：" prop="userName">
      <el-input v-model="ruleForm.userName"></el-input>
    </el-form-item>
    <el-form-item label="密码：" prop="userPassword">
      <el-input type="password" v-model="ruleForm.userPassword" autocomplete="off"></el-input>
    </el-form-item>
    <el-form-item>
      <el-button type="primary" @click="submitForm" >登录</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
export default {
  data() {
    return {
      ruleForm: {
        userName: "test",
        userPassword: "123",
      }
    };
  },
  methods: {
    submitForm() {
        // const loading = this.$loading({
        //   lock: true,
        //   text: 'Loading',
        //   spinner: 'el-icon-loading',
        //   background: 'rgba(0, 0, 0, 0.7)'
        // });
        // setTimeout(() => {
        //   loading.close();
        // }, 2000);
      var res = userLogin(this.ruleForm.userName, this.ruleForm.userPassword);
      var resJson = JSON.parse(res);
      if (resJson.success) {
        this.$alert("登录成功!", "成功!");
        var resData = JSON.parse(resJson.data);
        this.$router.replace({
          path: "/",
          query: {
            userName: resData.userName,
            token: resData.token
          }
        });
      } else {
        this.$alert(res.errMsg, "失败!");
      }
    }
  }
};
</script>

<style scoped>
.login-from {
  padding-left: 33%;
  padding-top: 13%;
  height: 400px;
  width: 30%;
}
</style>
