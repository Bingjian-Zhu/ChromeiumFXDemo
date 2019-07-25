<template>
  <div>
    <div @click="openWindows()">
      <i style="font-size: 40px;" class="el-icon-video-camera"></i>
    </div>
    <div @click="closeWindows()">
      <i style="font-size: 40px;" class="el-icon-close"></i>
    </div>
    <div align="center" class="calendar">
      <el-calendar v-model="value"></el-calendar>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
     url:"http://localhost:8080/#/Camera"
    };
  },
  methods: {
    closeWindows() {
      closefrm();
    },
    openWindows() {
      newpage(this.url);
    }
  }
};
</script>

<style scoped>
.el-icon-close {
  position: absolute;
  right: 0px;
  top: 0px;
}
.el-icon-video-camera {
  position: absolute;
  right: 50px;
  top: 0px;
}
.calendar {
  position: absolute;
  top: 15%;
  left: 15%;
  width: 70%;
}
</style>