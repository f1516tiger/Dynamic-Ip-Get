# Dynamic-Ip-Get
目的是为了除了世界服能有独立动态Ip,实时更新ip地址配合路由器dmz做穿透,基于windos服务的socket连接而已，但是还是需要一个公网服务器来获取


update to .net 4.8
usage
1.DynamicIpServer build and put it in to vps or other ECS,run setup.bat for windowsService
2.DyanmicIpServerLocal build and put it in  to u want use service Long-time-on computers on the local area network，run setup.bat for windows service
3.GetCompanyPublicIp build is winform,set DynamicIpServer 1. ip address and port,get ip,now u konw 2. dyanmicIp
4.In your router set dmz or port forwarding，in your app can get your service
