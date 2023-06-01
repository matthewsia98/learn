import logging

standard_logger = logging.getLogger("Standard Logger")
print(standard_logger.name)

standard_logger.debug("This is a debug message")
standard_logger.info("This is an info message")
standard_logger.warning("This is a warning message")
standard_logger.error("This is an error message")
standard_logger.critical("This is a critical message")

print()

file_logger = logging.getLogger("File Logger")
print(file_logger.name)

file_logger.setLevel(logging.DEBUG)
file_handler = logging.FileHandler("logfile.log")
file_logger.addHandler(file_handler)
file_logger.debug("This is a debug message")
file_logger.info("This is an info message")
file_logger.warning("This is a warning message")
file_logger.error("This is an error message")
file_logger.critical("This is a critical message")

file_handler.setFormatter(logging.Formatter(logging.BASIC_FORMAT))
file_logger.debug("This is a debug message")
file_logger.info("This is an info message")
file_logger.warning("This is a warning message")
file_logger.error("This is an error message")
file_logger.critical("This is a critical message")
