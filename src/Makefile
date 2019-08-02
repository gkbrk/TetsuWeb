.PHONY: all
all:
	dotnet build

.PHONY: test
test:
	dotnet test

.PHONY: watchbuild
watchbuild:
	while true; do inotifywait -e modify -r .; dotnet build; done;

.PHONY: watchtest
watchtest:
	while true; do inotifywait -e modify -r .; dotnet test; done;
