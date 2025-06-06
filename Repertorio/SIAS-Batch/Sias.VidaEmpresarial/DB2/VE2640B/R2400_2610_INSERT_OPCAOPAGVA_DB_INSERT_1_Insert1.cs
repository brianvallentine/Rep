using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R2400_2610_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 : QueryBasis<R2400_2610_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL
            (NUM_CERTIFICADO,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA,
            OPCAO_PAGAMENTO,
            PERI_PAGAMENTO,
            DIA_DEBITO,
            COD_USUARIO,
            TIMESTAMP,
            COD_AGENCIA_DEBITO,
            OPE_CONTA_DEBITO,
            NUM_CONTA_DEBITO,
            DIG_CONTA_DEBITO,
            NUM_CARTAO_CREDITO)
            VALUES (:NUMEROUT-NUM-CERT-VGAP,
            :HISCOBPR-DATA-INIVIGENCIA,
            '9999-12-31' ,
            :OPCPAGVI-OPCAO-PAGAMENTO,
            :SUBGVGAP-PERI-FATURAMENTO,
            :OPCPAGVI-DIA-DEBITO,
            'VE2640B' ,
            CURRENT TIMESTAMP,
            :OPCPAGVI-COD-AGENCIA-DEBITO:N-NULL-1,
            :OPCPAGVI-OPE-CONTA-DEBITO:N-NULL-1,
            :OPCPAGVI-NUM-CONTA-DEBITO:N-NULL-1,
            :OPCPAGVI-DIG-CONTA-DEBITO:N-NULL-1,
            :OPCPAGVI-NUM-CARTAO-CREDITO:N-NULL-1)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL (NUM_CERTIFICADO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, OPCAO_PAGAMENTO, PERI_PAGAMENTO, DIA_DEBITO, COD_USUARIO, TIMESTAMP, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO) VALUES ({FieldThreatment(this.NUMEROUT_NUM_CERT_VGAP)}, {FieldThreatment(this.HISCOBPR_DATA_INIVIGENCIA)}, '9999-12-31' , {FieldThreatment(this.OPCPAGVI_OPCAO_PAGAMENTO)}, {FieldThreatment(this.SUBGVGAP_PERI_FATURAMENTO)}, {FieldThreatment(this.OPCPAGVI_DIA_DEBITO)}, 'VE2640B' , CURRENT TIMESTAMP,  {FieldThreatment((this.N_NULL_1?.ToInt() == -1 ? null : this.OPCPAGVI_COD_AGENCIA_DEBITO))},  {FieldThreatment((this.N_NULL_1?.ToInt() == -1 ? null : this.OPCPAGVI_OPE_CONTA_DEBITO))},  {FieldThreatment((this.N_NULL_1?.ToInt() == -1 ? null : this.OPCPAGVI_NUM_CONTA_DEBITO))},  {FieldThreatment((this.N_NULL_1?.ToInt() == -1 ? null : this.OPCPAGVI_DIG_CONTA_DEBITO))},  {FieldThreatment((this.N_NULL_1?.ToInt() == -1 ? null : this.OPCPAGVI_NUM_CARTAO_CREDITO))})";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string N_NULL_1 { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }

        public static void Execute(R2400_2610_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 r2400_2610_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1)
        {
            var ths = r2400_2610_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2400_2610_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}