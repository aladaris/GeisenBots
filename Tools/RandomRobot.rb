#!/usr/bin/ruby
require 'securerandom'
require 'optparse'

NINPUTS = 20
NROWS = 128 - NINPUTS
ROWLENGHT = 18
BFUNCTIONSIZE = 4
BPARAMETERSIZE = 7
NPROGRAMS = 5
SEPARATOR = ';'
TSEPARATOR = '|'
FILEEXTENSION = 'rxt'

# Parameter handling
options = {}
options[:filename] = "eisenRobot"
OptionParser.new do |opts|
    opts.banner = "Usage: #{opts.program_name} [options]"

    opts.on("-f FILENAME", String, "Output Filename (without extension)") do |f|
        options[:filename] = f
    end
    opts.on("-n N", Integer, "Number of robots to generate") do |n|
        options[:number] = n
    end
end.parse!

def RandomRow
    row = SecureRandom.random_number((2**ROWLENGHT)-1).to_s(2)
    while (row.size < ROWLENGHT) # TODO: hacerlo más "ruby style"
        row = "0" << row
    end
    row
end

def RandomTableRex
    table = ""
    for i in 0..NROWS-1
        table << RandomRow()
        table << SEPARATOR if i < NROWS - 1
    end
    table
end

def RandomRobotProgram
    program = ""
    for i in 0..NPROGRAMS-1
        program << RandomTableRex()
        program << TSEPARATOR if i < NPROGRAMS - 1
    end
    program
end

def GenerateRandomRobot (path)
    filename = (/[^\\]*$/.match path).to_s
    dirpath = path.split("\\")
    dirpath.delete(filename)
    dirpath.delete("")

    fullpath = ""
    for dir in dirpath
        fullpath << dir + '\\'
        if (not Dir.exists? fullpath)
            Dir.mkdir fullpath
        end
    end

    output = File.new(fullpath + '\\' + filename, "w")
    output << RandomRobotProgram()
    output.close
end

# "main"
if options[:number]
    for i in 0..options[:number]-1
        GenerateRandomRobot(options[:filename]+"_#{i.to_s}.#{FILEEXTENSION}")
    end
else
    GenerateRandomRobot (options[:filename]+".#{FILEEXTENSION}")
end
