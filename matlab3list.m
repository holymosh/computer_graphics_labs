script;
echo off all;
close all;
I = imread('cameraman.tif');
imshow(I);
Id = im2double(I);
h = fftshift(fft2(Id) );
figure, imshow( mat2gray(log10(abs(h))));
Io = ifft2(fftshift(h));
figure, imshow(mat2gray(Io));
clear;
echo off all;
close all;
I=imread('liftingbody.png');
imshow(I);
S = qtdecomp(I,.27);
M = full(S);
figure,imshow(M);
blocks = repmat(uint8(0),size(S));
for dim = [512 256 128 64 32 16 8 4 2 1];
   numblocks = length(find(S==dim));
   if(numblocks >0)
       values = repmat(uint8(1),[dim dim numblocks]);
       values(2:dim,2:dim,:) = 0;
       blocks = qtsetblk(blocks,S,dim,values);
   end
end
blocks(end,1:end) = 1;
blocks(1:end,end) = 1;
figure,imshow(blocks,[])
