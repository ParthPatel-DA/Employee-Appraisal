<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Project - Copy.aspx.cs" Inherits="Admin_Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .group-control {
            padding: 10px 20px 10px 20px;
        }

        span {
            font-size: 12px;
        }
    </style>

    <!-- draggable and droppable style sheet -->
    <style>
        .droppable {
            margin: 10px;
            margin-bottom: 15px;
            padding: 20px;
        }

        .draggable {
            margin: 20px;
            margin-bottom: 15px;
            padding: 10px;
        }

        .ui-widget-header {
            border: 1px solid #dddddd;
            background: #e9e9e9;
            color: #333333;
            font-weight: bold;
        }

            .ui-widget-header a {
                color: #333333;
            }

            .ui-state-hover,
            .ui-widget-content .ui-state-hover,
            .ui-widget-header .ui-state-hover,
            .ui-state-focus,
            .ui-widget-content .ui-state-focus,
            .ui-widget-header .ui-state-focus,
            .ui-button:hover,
            .ui-button:focus {
                border: 1px solid #cccccc;
                background: #ededed;
                font-weight: normal;
                color: #2b2b2b;
            }

            .ui-state-active,
            .ui-widget-content .ui-state-active,
            .ui-widget-header .ui-state-active,
            a.ui-button:active,
            .ui-button:active,
            .ui-button.ui-state-active:hover {
                border: 1px solid #003eff;
                background: #007fff;
                font-weight: normal;
                color: #ffffff;
            }

            .ui-state-highlight,
            .ui-widget-content .ui-state-highlight,
            .ui-widget-header .ui-state-highlight {
                border: 1px solid #dad55e;
                background: #fffa90;
                color: #777620;
            }

                .ui-state-highlight a,
                .ui-widget-content .ui-state-highlight a,
                .ui-widget-header .ui-state-highlight a {
                    color: #777620;
                }

            .ui-state-error,
            .ui-widget-content .ui-state-error,
            .ui-widget-header .ui-state-error {
                border: 1px solid #f1a899;
                background: #fddfdf;
                color: #5f3f3f;
            }

                .ui-state-error a,
                .ui-widget-content .ui-state-error a,
                .ui-widget-header .ui-state-error a {
                    color: #5f3f3f;
                }

            .ui-state-error-text,
            .ui-widget-content .ui-state-error-text,
            .ui-widget-header .ui-state-error-text {
                color: #5f3f3f;
            }

            .ui-priority-primary,
            .ui-widget-content .ui-priority-primary,
            .ui-widget-header .ui-priority-primary {
                font-weight: bold;
            }

            .ui-priority-secondary,
            .ui-widget-content .ui-priority-secondary,
            .ui-widget-header .ui-priority-secondary {
                opacity: .7;
                filter: Alpha(Opacity=70); /* support: IE8 */
                font-weight: normal;
            }

            .ui-state-disabled,
            .ui-widget-content .ui-state-disabled,
            .ui-widget-header .ui-state-disabled {
                opacity: .35;
                filter: Alpha(Opacity=35); /* support: IE8 */
                background-image: none;
            }

        }

        .ui-widget-header .ui-icon {
            background-image: url("images/ui-icons_444444_256x240.png");
        }

        /*drag*/


        .ui-controlgroup-horizontal .ui-controlgroup-label.ui-widget-content {
            border-right: none;
        }

        .ui-controlgroup-vertical .ui-controlgroup-label.ui-widget-content {
            border-bottom: none;
        }

        .ui-widget.ui-widget-content {
            border: 1px solid #c5c5c5;
        }

        .ui-widget-content {
            border: 1px solid #4D4D4D;
            background: #DB6969;
            color: #ffffff;
        }

            .ui-widget-content a {
                color: #333333;
            }

            .ui-widget-content .ui-icon {
                background-image: url("images/ui-icons_444444_256x240.png");
            }
    </style>
    <!-- /draggable and droppable style sheet -->

    
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $(".draggable").draggable();

            $(".droppable").droppable({
                classes: {
                    "ui-droppable-active": "ui-state-active",
                    "ui-droppable-hover": "ui-state-hover"
                },
                drop: function (event, ui) {
                    $(this)
                      .addClass("ui-state-highlight")
                      .find("> p")
                        .html("Dropped!");
                    return false;
                }
            });


        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="display: inline-block; margin-bottom: 30px; width: 100%;">
        <!-- Add Project -->
        <div class="col-md-12">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Add Project</h6>
                </div>
            </div>
            <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; padding: 20px;">

                <div class="col-md-6 group-control">
                    <span>Project Name :</span>
                    <div class="controls">
                        <asp:TextBox ID="txtmail" runat="server" Style="width: 100%;"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6 group-control">
                    <span>Client :</span>
                    <div class="controls">
                        <asp:TextBox ID="TextBox6" runat="server" Style="width: 100%;"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 group-control">
                    <span>Title :</span>
                    <div class="controls">
                        <asp:TextBox ID="TextBox4" runat="server" Style="width: 100%;"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 group-control">
                    <span>Category :</span>
                    <div class="controls">
                        <asp:TextBox ID="TextBox2" runat="server" Style="width: 100%;"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 group-control">
                    <span>Language :</span>
                    <div class="controls">
                        <asp:TextBox ID="TextBox3" runat="server" Style="width: 100%;"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 group-control">
                    <span>Deadline :</span>
                    <div class="controls">
                        <asp:TextBox ID="TextBox7" runat="server" Style="width: 100%;"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12 group-control">
                    <span>Description :</span>
                    <div class="controls">
                        <asp:TextBox ID="TextBox5" class="form" runat="server" Style="width: 100%; height: 150px;" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4 group-control">
                    <div class="controls">
                        <asp:Button ID="btnAddProject" runat="server" Text="Add Project" class="btn  btn-primary form-control" BackColor="#4d4d4d" Style="margin-bottom: 10px;" OnClick="btnAddProject_Click" />
                    </div>
                </div>


            </div>
        </div>
        <!-- /Add Project -->

        <!-- View Employee -->
        <div class="col-md-6 pull-right">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Employee Detail</h6>
                </div>
            </div>
            <div style="border: 1px solid #CAC8C8; display: inline-block; width: 100%; padding: 20px; max-height: 500px;">
                <div id="" class="ui-widget-header droppable">
                    <h4>Outer droppable</h4>
                </div>
                <div id="" class="ui-widget-header droppable">
                    <h4>Outer droppable</h4>
                </div>
                <div id="" class="ui-widget-header droppable">
                    <h4>Outer droppable</h4>
                </div>


            </div>
        </div>
        <!-- /View Employee -->

        <!-- View Project -->
        <div class="col-md-6">
            <div style="margin-bottom: 1px;">
                <div class="navbar-inner">
                    <h6>Project Detail</h6>
                </div>
            </div>
            <div style="border: 1px solid #CAC8C8; display: inline-block; overflow: auto; width: 100%; padding: 20px; max-height: 500px;">

                <div id="" class="ui-widget-content draggable">
                    <h4>Project 1</h4>
                </div>
                <div id="" class="ui-widget-content draggable">
                    <h4>Project 2</h4>
                </div>
                <div id="" class="ui-widget-content draggable">
                    <h4>Project 3</h4>
                </div>
                <div id="" class="ui-widget-content draggable">
                    <h4>Project 1</h4>
                </div>
                <div id="" class="ui-widget-content draggable">
                    <h4>Project 2</h4>
                </div>
                <div id="" class="ui-widget-content draggable">
                    <h4>Project 3</h4>
                </div>



            </div>
        </div>
        <!-- /View Project -->
    </div>
</asp:Content>

