using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1 : QueryBasis<R1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.APOLICE_COBRANCA
            (COD_EMPRESA ,
            COD_FONTE ,
            NUM_APOLICE ,
            NUM_ENDOSSO ,
            COD_PRODUTO ,
            NUM_MATRICULA ,
            TIPO_COBRANCA ,
            AGE_COBRANCA ,
            COD_AGENCIA ,
            OPERACAO_CONTA ,
            NUM_CONTA ,
            DIG_CONTA ,
            COD_AGENCIA_DEB ,
            OPER_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            NUM_CARTAO ,
            DIA_DEBITO ,
            NR_CERTIF_AUTO ,
            TIMESTAMP ,
            MARGEM_COMERCIAL)
            VALUES (:APOLCOBR-COD-EMPRESA ,
            :APOLCOBR-COD-FONTE ,
            :APOLCOBR-NUM-APOLICE ,
            :APOLCOBR-NUM-ENDOSSO ,
            :APOLCOBR-COD-PRODUTO ,
            :APOLCOBR-NUM-MATRICULA ,
            :APOLCOBR-TIPO-COBRANCA ,
            :APOLCOBR-AGE-COBRANCA ,
            :APOLCOBR-COD-AGENCIA ,
            :APOLCOBR-OPERACAO-CONTA ,
            :APOLCOBR-NUM-CONTA ,
            :APOLCOBR-DIG-CONTA ,
            :APOLCOBR-COD-AGENCIA-DEB:VIND-AGENCIA ,
            :APOLCOBR-OPER-CONTA-DEB :VIND-OPERACAO ,
            :APOLCOBR-NUM-CONTA-DEB :VIND-NUMCONTA ,
            :APOLCOBR-DIG-CONTA-DEB :VIND-DIGCONTA ,
            :APOLCOBR-NUM-CARTAO :VIND-CARTAO-CREDITO,
            :APOLCOBR-DIA-DEBITO :VIND-DIADEBITO,
            :APOLCOBR-NR-CERTIF-AUTO :VIND-NRCERTIF ,
            CURRENT TIMESTAMP ,
            :APOLCOBR-MARGEM-COMERCIAL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.APOLICE_COBRANCA (COD_EMPRESA , COD_FONTE , NUM_APOLICE , NUM_ENDOSSO , COD_PRODUTO , NUM_MATRICULA , TIPO_COBRANCA , AGE_COBRANCA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , NUM_CARTAO , DIA_DEBITO , NR_CERTIF_AUTO , TIMESTAMP , MARGEM_COMERCIAL) VALUES ({FieldThreatment(this.APOLCOBR_COD_EMPRESA)} , {FieldThreatment(this.APOLCOBR_COD_FONTE)} , {FieldThreatment(this.APOLCOBR_NUM_APOLICE)} , {FieldThreatment(this.APOLCOBR_NUM_ENDOSSO)} , {FieldThreatment(this.APOLCOBR_COD_PRODUTO)} , {FieldThreatment(this.APOLCOBR_NUM_MATRICULA)} , {FieldThreatment(this.APOLCOBR_TIPO_COBRANCA)} , {FieldThreatment(this.APOLCOBR_AGE_COBRANCA)} , {FieldThreatment(this.APOLCOBR_COD_AGENCIA)} , {FieldThreatment(this.APOLCOBR_OPERACAO_CONTA)} , {FieldThreatment(this.APOLCOBR_NUM_CONTA)} , {FieldThreatment(this.APOLCOBR_DIG_CONTA)} ,  {FieldThreatment((this.VIND_AGENCIA?.ToInt() == -1 ? null : this.APOLCOBR_COD_AGENCIA_DEB))} ,  {FieldThreatment((this.VIND_OPERACAO?.ToInt() == -1 ? null : this.APOLCOBR_OPER_CONTA_DEB))} ,  {FieldThreatment((this.VIND_NUMCONTA?.ToInt() == -1 ? null : this.APOLCOBR_NUM_CONTA_DEB))} ,  {FieldThreatment((this.VIND_DIGCONTA?.ToInt() == -1 ? null : this.APOLCOBR_DIG_CONTA_DEB))} ,  {FieldThreatment((this.VIND_CARTAO_CREDITO?.ToInt() == -1 ? null : this.APOLCOBR_NUM_CARTAO))},  {FieldThreatment((this.VIND_DIADEBITO?.ToInt() == -1 ? null : this.APOLCOBR_DIA_DEBITO))},  {FieldThreatment((this.VIND_NRCERTIF?.ToInt() == -1 ? null : this.APOLCOBR_NR_CERTIF_AUTO))} , CURRENT TIMESTAMP , {FieldThreatment(this.APOLCOBR_MARGEM_COMERCIAL)})";

            return query;
        }
        public string APOLCOBR_COD_EMPRESA { get; set; }
        public string APOLCOBR_COD_FONTE { get; set; }
        public string APOLCOBR_NUM_APOLICE { get; set; }
        public string APOLCOBR_NUM_ENDOSSO { get; set; }
        public string APOLCOBR_COD_PRODUTO { get; set; }
        public string APOLCOBR_NUM_MATRICULA { get; set; }
        public string APOLCOBR_TIPO_COBRANCA { get; set; }
        public string APOLCOBR_AGE_COBRANCA { get; set; }
        public string APOLCOBR_COD_AGENCIA { get; set; }
        public string APOLCOBR_OPERACAO_CONTA { get; set; }
        public string APOLCOBR_NUM_CONTA { get; set; }
        public string APOLCOBR_DIG_CONTA { get; set; }
        public string APOLCOBR_COD_AGENCIA_DEB { get; set; }
        public string VIND_AGENCIA { get; set; }
        public string APOLCOBR_OPER_CONTA_DEB { get; set; }
        public string VIND_OPERACAO { get; set; }
        public string APOLCOBR_NUM_CONTA_DEB { get; set; }
        public string VIND_NUMCONTA { get; set; }
        public string APOLCOBR_DIG_CONTA_DEB { get; set; }
        public string VIND_DIGCONTA { get; set; }
        public string APOLCOBR_NUM_CARTAO { get; set; }
        public string VIND_CARTAO_CREDITO { get; set; }
        public string APOLCOBR_DIA_DEBITO { get; set; }
        public string VIND_DIADEBITO { get; set; }
        public string APOLCOBR_NR_CERTIF_AUTO { get; set; }
        public string VIND_NRCERTIF { get; set; }
        public string APOLCOBR_MARGEM_COMERCIAL { get; set; }

        public static void Execute(R1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1 r1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1)
        {
            var ths = r1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1160_00_INSERT_APOLCOBR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}