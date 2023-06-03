#!/usr/bin/env python3
import argparse
import sys

print(f"\n{sys.argv=}")

parser = argparse.ArgumentParser()
parser.add_argument("filenames", nargs="*", help="list of files")
parser.add_argument("--version", action="version", version="%(prog)s version 2.0")
parser.add_argument("-v", "--verbose", action="store_true", help="verbose output")

args = parser.parse_args()
print(f"\n{args=}")

if args.filenames == ["-"]:
    print("\nReading from stdin")
    print(list(enumerate(sys.stdin)))
