//AJOUT DANS LES BASES DE DONNEES
try
{
    //AJOUT DANS DEPENSE
    OleDbCommand cdInsert = new OleDbCommand(@"INSERT INTO Depenses (numDepense,description,montant,dateDepense,commentaire,codeEvent,codePart)
                                                         VALUES (?,?,?,?,?,?,?)", connect);

    OleDbCommand cdCodeEvent = new OleDbCommand("SELECT codeEvent FROM Evenements WHERE titreEvent='" + cboEvent.Text + "'", connect);
    int codeEvent = Convert.ToInt32(cdCodeEvent.ExecuteScalar().ToString());
    OleDbCommand cdCodePart = new OleDbCommand("SELECT codeParticipant FROM Participants WHERE nomPart='" + cboPayer.Text.Split(' ')[0] + "'", connect);

    OleDbCommand recupNumDepense = new OleDbCommand("SELECT numDepense FROM Depenses ORDER BY numDepense DESC", connect);

    int numDepense = Convert.ToInt32(recupNumDepense.ExecuteScalar().ToString()) + 1;

    cdInsert.Parameters.Add(new OleDbParameter("numDepense", OleDbType.Integer)).Value = numDepense;
    cdInsert.Parameters.Add(new OleDbParameter("description", OleDbType.WChar)).Value = cboEvent.Text;
    cdInsert.Parameters.Add(new OleDbParameter("montant", OleDbType.Currency)).Value = textBox2.Text;
    cdInsert.Parameters.Add(new OleDbParameter("dateDepense", OleDbType.Date)).Value = dtDate.Value.ToString();
    cdInsert.Parameters.Add(new OleDbParameter("commentaire", OleDbType.WChar)).Value = rtxtCommentaire.Text;
    cdInsert.Parameters.Add(new OleDbParameter("codeEvent", OleDbType.Integer)).Value = codeEvent;
    cdInsert.Parameters.Add(new OleDbParameter("codePart", OleDbType.Integer)).Value = Convert.ToInt32(cboPayer.Tag);

    if (cboEvent.Text == "")
    {
        MessageBox.Show("La case événement n'est pas valide !", "La dépense n'a pas été ajouté", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else if (cboPayer.Text == "")
    {
        MessageBox.Show("Le payeur n'est pas valide !", "La dépense n'a pas été ajouté", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else if (textBox1.Text == "")
    {
        MessageBox.Show("Le sujet de la dépense n'est pas valide !", "La dépense n'a pas été ajouté", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else if (textBox2.Text == "")
    {
        MessageBox.Show("Le montant de la dépense n'est pas valide !", "La dépense n'a pas été ajouté", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else if (dtDate.Value < new DateTime())
    {
        MessageBox.Show("La date de la dépense n'est pas valide !", "La dépense n'a pas été ajouté", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else if (rtxtCommentaire.Text == "")
    {
        MessageBox.Show("La case commentaire est vide !", "La dépense n'a pas été ajouté", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else
    {
        cdInsert.ExecuteNonQuery();


        //AJOUT DANS BENEFICIAIRE

        OleDbCommand insertBenef = new OleDbCommand(@"INSERT INTO Beneficiaires(numDepense,codePart)
                                                                    VALUES (?,?)", connect);

        for (int i = 0; i < clbBeneficiaire.CheckedItems.Count; i++)
        {
            OleDbCommand recupNumPart = new OleDbCommand("SELECT codeParticipant FROM Participants WHERE nomPart='" + clbBeneficiaire.CheckedItems[i].ToString().Split(' ')[0] + "'", connect);

            insertBenef.Parameters.Add(new OleDbParameter("numDepense", OleDbType.Integer)).Value = numDepense;
            insertBenef.Parameters.Add(new OleDbParameter("codePart", OleDbType.Integer)).Value = Convert.ToInt32(recupNumPart.ExecuteScalar().ToString());

            insertBenef.ExecuteNonQuery();
        }
        insertBenef.Parameters.Add(new OleDbParameter("numDepense", OleDbType.Integer)).Value = numDepense;
        insertBenef.Parameters.Add(new OleDbParameter("codePart", OleDbType.Integer)).Value = Convert.ToInt32(cbPayeur.Tag.ToString());

        insertBenef.ExecuteNonQuery();
        MessageBox.Show("La dépense a été validé !", "Dépense enregistrée", MessageBoxButtons.OK);
    }
}
catch (Exception ex)
{
    MessageBox.Show("Probleme avec l'accès à la base de donnée : \n\n" + ex.Message);
}

