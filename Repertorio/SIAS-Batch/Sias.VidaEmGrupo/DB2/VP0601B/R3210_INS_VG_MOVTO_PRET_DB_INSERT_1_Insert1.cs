using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1 : QueryBasis<R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_MOVTO_PRESTAMISTA
            ( NUM_CERTIFICADO
            ,NUM_PARCELA
            ,DTA_VENCIMENTO
            ,VLR_PARCELA
            ,STA_REGISTRO
            ,COD_IDLG
            ,COD_RETORNO
            ,DES_RETORNO
            ,COD_CONVENIO
            ,NUM_BANCO_DEBITO
            ,NUM_AGENCIA_DEBITO
            ,NUM_CONTA_DEBITO
            ,NOM_PROGRAMA
            ,DTH_ATUALIZACAO
            ,DTA_PROXIMA_COBRANCA)
            VALUES
            ( :VG096-NUM-CERTIFICADO
            ,:VG096-NUM-PARCELA
            ,:VG096-DTA-VENCIMENTO
            ,:VG096-VLR-PARCELA
            ,:VG096-STA-REGISTRO
            ,:VG096-COD-IDLG
            ,:VG096-COD-RETORNO
            ,:VG096-DES-RETORNO
            ,:VG096-COD-CONVENIO
            ,:VG096-NUM-BANCO-DEBITO
            ,:VG096-NUM-AGENCIA-DEBITO
            ,:VG096-NUM-CONTA-DEBITO
            ,:VG096-NOM-PROGRAMA
            , CURRENT TIMESTAMP
            ,:VG096-DTA-PROXIMA-COBRANCA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_MOVTO_PRESTAMISTA ( NUM_CERTIFICADO ,NUM_PARCELA ,DTA_VENCIMENTO ,VLR_PARCELA ,STA_REGISTRO ,COD_IDLG ,COD_RETORNO ,DES_RETORNO ,COD_CONVENIO ,NUM_BANCO_DEBITO ,NUM_AGENCIA_DEBITO ,NUM_CONTA_DEBITO ,NOM_PROGRAMA ,DTH_ATUALIZACAO ,DTA_PROXIMA_COBRANCA) VALUES ( {FieldThreatment(this.VG096_NUM_CERTIFICADO)} ,{FieldThreatment(this.VG096_NUM_PARCELA)} ,{FieldThreatment(this.VG096_DTA_VENCIMENTO)} ,{FieldThreatment(this.VG096_VLR_PARCELA)} ,{FieldThreatment(this.VG096_STA_REGISTRO)} ,{FieldThreatment(this.VG096_COD_IDLG)} ,{FieldThreatment(this.VG096_COD_RETORNO)} ,{FieldThreatment(this.VG096_DES_RETORNO)} ,{FieldThreatment(this.VG096_COD_CONVENIO)} ,{FieldThreatment(this.VG096_NUM_BANCO_DEBITO)} ,{FieldThreatment(this.VG096_NUM_AGENCIA_DEBITO)} ,{FieldThreatment(this.VG096_NUM_CONTA_DEBITO)} ,{FieldThreatment(this.VG096_NOM_PROGRAMA)} , CURRENT TIMESTAMP ,{FieldThreatment(this.VG096_DTA_PROXIMA_COBRANCA)})";

            return query;
        }
        public string VG096_NUM_CERTIFICADO { get; set; }
        public string VG096_NUM_PARCELA { get; set; }
        public string VG096_DTA_VENCIMENTO { get; set; }
        public string VG096_VLR_PARCELA { get; set; }
        public string VG096_STA_REGISTRO { get; set; }
        public string VG096_COD_IDLG { get; set; }
        public string VG096_COD_RETORNO { get; set; }
        public string VG096_DES_RETORNO { get; set; }
        public string VG096_COD_CONVENIO { get; set; }
        public string VG096_NUM_BANCO_DEBITO { get; set; }
        public string VG096_NUM_AGENCIA_DEBITO { get; set; }
        public string VG096_NUM_CONTA_DEBITO { get; set; }
        public string VG096_NOM_PROGRAMA { get; set; }
        public string VG096_DTA_PROXIMA_COBRANCA { get; set; }

        public static void Execute(R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1 r3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1)
        {
            var ths = r3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}