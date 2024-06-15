class OutOfTuneException(Exception):
    pass

class BrokenStringException(Exception):
    pass

def play_guitar():
    try:
        raise OutOfTuneException("The guitar is out of tune!")
    except OutOfTuneException as e:
        raise BrokenStringException("A string broke!") from e

try:
    play_guitar()
except BrokenStringException as e:
    print(f"Caught exception: {str(e)}")
    print(f"Original exception: {str(e.__cause__)}")