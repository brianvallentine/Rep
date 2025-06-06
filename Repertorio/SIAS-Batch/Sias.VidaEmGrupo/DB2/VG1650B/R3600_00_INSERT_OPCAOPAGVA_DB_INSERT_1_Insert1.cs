using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 : QueryBasis<R3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.OPCAO_PAG_VIDAZUL
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
            VALUES (:PROPOVA-NUM-CERTIFICADO,
            :OPCPAGVI-DATA-INIVIGENCIA,
            :OPCPAGVI-DATA-TERVIGENCIA,
            :OPCPAGVI-OPCAO-PAGAMENTO,
            :MOVIMVGA-PERI-PAGAMENTO,
            :OPCPAGVI-DIA-DEBITO,
            'VG1650B' ,
            CURRENT TIMESTAMP,
            :OPCPAGVI-COD-AGENCIA-DEBITO:WHOST-IND,
            :OPCPAGVI-OPE-CONTA-DEBITO:WHOST-IND,
            :OPCPAGVI-NUM-CONTA-DEBITO:WHOST-IND,
            :OPCPAGVI-DIG-CONTA-DEBITO:WHOST-IND,
            :OPCPAGVI-NUM-CARTAO-CREDITO:WHOST-IND-CRT)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL (NUM_CERTIFICADO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, OPCAO_PAGAMENTO, PERI_PAGAMENTO, DIA_DEBITO, COD_USUARIO, TIMESTAMP, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO) VALUES ({FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, {FieldThreatment(this.OPCPAGVI_DATA_INIVIGENCIA)}, {FieldThreatment(this.OPCPAGVI_DATA_TERVIGENCIA)}, {FieldThreatment(this.OPCPAGVI_OPCAO_PAGAMENTO)}, {FieldThreatment(this.MOVIMVGA_PERI_PAGAMENTO)}, {FieldThreatment(this.OPCPAGVI_DIA_DEBITO)}, 'VG1650B' , CURRENT TIMESTAMP,  {FieldThreatment((this.WHOST_IND?.ToInt() == -1 ? null : this.OPCPAGVI_COD_AGENCIA_DEBITO))},  {FieldThreatment((this.WHOST_IND?.ToInt() == -1 ? null : this.OPCPAGVI_OPE_CONTA_DEBITO))},  {FieldThreatment((this.WHOST_IND?.ToInt() == -1 ? null : this.OPCPAGVI_NUM_CONTA_DEBITO))},  {FieldThreatment((this.WHOST_IND?.ToInt() == -1 ? null : this.OPCPAGVI_DIG_CONTA_DEBITO))},  {FieldThreatment((this.WHOST_IND_CRT?.ToInt() == -1 ? null : this.OPCPAGVI_NUM_CARTAO_CREDITO))})";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string OPCPAGVI_DATA_INIVIGENCIA { get; set; }
        public string OPCPAGVI_DATA_TERVIGENCIA { get; set; }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string MOVIMVGA_PERI_PAGAMENTO { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string WHOST_IND { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string WHOST_IND_CRT { get; set; }

        public static void Execute(R3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 r3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1)
        {
            var ths = r3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3600_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}