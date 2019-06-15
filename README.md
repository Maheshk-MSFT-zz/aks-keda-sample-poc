# aks-keda-sample-poc
Based on https://github.com/kedacore/sample-hello-world-azure-functions learning


How to build and watch (useful commands) 
==============================================
$docker build . -t <your-docker-id>/hello-keda:1.0
 
$docker push <your-docker-id>/hello-keda:1.0
 
$func kubernetes deploy --name hello-keda --image-name <your-docker-id>/hello-keda:1
 
$kubectl get pod -w

$kubectl get deploy -w

$kubectl get hpa -w

MUST
====
 .dockerignore omits copying "local.settings.json(sensitive details) file into Docker image 
 .gitignore excludes copying file into Github (Idea is to drop local.settings.json leaving our box) 
 
 KEDA project
 https://github.com/kedacore/keda
 
 Azure webinar - Build Event-Driven Containers with Azure Functions on Kubernetes
 https://info.microsoft.com/ww-ondemand-Build-Event-Driven-Containers-with-Azure-Functions-on-Kubernetes.html
