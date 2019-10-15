# Unity 组件调试工具



# 背景
 工作中遇到的一些痛点，催发了这个工具的诞生。
- 你在修BUG或者做需求的时候
	- 是否想直接**查看**组件实例的某个**字段**
	- 是否想直接**修改**组件实例的某个**字段**
		- 比如修改 private float speed 私有速度值
		- 比如修改 private Data data 私有自定义类型值
	- 是否想直接**调用**组件实例的某个**方法**
		- 比如调用 Start() 方法调试
		- 比如调用 Play(float time) 播放方法调试
	
虽然以上需求Unity都有方法实现，
但是缺点是需要修改代码。

# 效果展示
- 一个简单的组件

```
using UnityEngine;

public class Data { }

public class Demo : MonoBehaviour
{
    private float speed;

    private Data data;

    private void Start() { }

    private void Play(float time) { }
}
```

- 挂载到GameObject后使用工具
- 自动挂载一个解析脚本ReflectionMonoBehaviour
- 在解析脚本中调试组件

![](https://i.imgur.com/u48LGS9.png)

# 安装
- 导入源码到你的项目中 
- 路径随便修改


# 使用方式

- 在**组件菜单**中点击**反射**选项


![](https://i.imgur.com/RjorpcQ.png)



# 日志
## 2019年10月15日
- 上传第一版

# 后续优化点
- 新增搜索框方便查找字段和方法
- 新增修饰符快速分类
- 新增窗口调试模式
- 解析字典
- 数组List快速跳转顺序
- 解析多维数组
