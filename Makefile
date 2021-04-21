Service ?= simple-akka-cs

_build:
	@echo "Building simple-akka-cs..."
	docker build -t ${Service}:latest .

_run:
	@echo "Running simple-akka-cs service..."
	docker run -it -p 5000:80 ${Service}:latest .
