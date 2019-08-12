.PHONY: all
all:
	dotnet build

.PHONY: test
test: all
	prove -j4

.PHONY: watchbuild
watchbuild:
	while true; do inotifywait -e modify -r .; make all; done;

.PHONY: watchtest
watchtest:
	while true; do inotifywait -e modify -r .; make test; done;
