import sys, time, os, json

# Simulated input from C#
prompt = sys.argv[1]
output_path = sys.argv[2]

# Fake video generation (simulated)
print(f"Generating video for prompt: {prompt}")
time.sleep(2)

# dummy MP4 file to simulate output
with open(output_path, "w") as f:
    f.write("FAKE_VIDEO_DATA")

print(f"Video saved to {output_path}")
