﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Noti.Data;

#nullable disable

namespace Noti.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230409195442_Non-virtual-profile")]
    partial class Nonvirtualprofile
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Noti.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<int>("SubCommentId")
                        .HasColumnType("int");

                    b.Property<int>("VirtualProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCommentId");

                    b.HasIndex("VirtualProfileId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Noti.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PostImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PostOwnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostShareDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostOwnerId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Noti.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FollowersId")
                        .HasColumnType("int");

                    b.Property<int>("FollowingId")
                        .HasColumnType("int");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostsId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ProfilePhoto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("VirtualProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FollowersId");

                    b.HasIndex("FollowingId");

                    b.HasIndex("PostsId");

                    b.HasIndex("VirtualProfileId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Noti.Entities.SubComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<int>("VirtualProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VirtualProfileId");

                    b.ToTable("SubComments");
                });

            modelBuilder.Entity("Noti.Entities.VirtualProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("VirtualProfile");
                });

            modelBuilder.Entity("Noti.Entities.Comment", b =>
                {
                    b.HasOne("Noti.Entities.SubComment", "SubComment")
                        .WithMany()
                        .HasForeignKey("SubCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noti.Entities.VirtualProfile", "VirtualProfile")
                        .WithMany()
                        .HasForeignKey("VirtualProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubComment");

                    b.Navigation("VirtualProfile");
                });

            modelBuilder.Entity("Noti.Entities.Post", b =>
                {
                    b.HasOne("Noti.Entities.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("Noti.Entities.VirtualProfile", "PostOwner")
                        .WithMany()
                        .HasForeignKey("PostOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("PostOwner");
                });

            modelBuilder.Entity("Noti.Entities.Profile", b =>
                {
                    b.HasOne("Noti.Entities.VirtualProfile", "Followers")
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noti.Entities.VirtualProfile", "Following")
                        .WithMany()
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noti.Entities.Post", "Posts")
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Noti.Entities.VirtualProfile", "VirtualProfile")
                        .WithMany()
                        .HasForeignKey("VirtualProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Followers");

                    b.Navigation("Following");

                    b.Navigation("Posts");

                    b.Navigation("VirtualProfile");
                });

            modelBuilder.Entity("Noti.Entities.SubComment", b =>
                {
                    b.HasOne("Noti.Entities.VirtualProfile", "VirtualProfile")
                        .WithMany()
                        .HasForeignKey("VirtualProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VirtualProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
