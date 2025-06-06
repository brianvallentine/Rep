using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class R1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1 : QueryBasis<R1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1>
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
            SELECT NUM_CERTIFICADO,
            :V1SIST-DTMOVABE,
            '9999-12-31' ,
            OPCAO_PAGAMENTO,
            PERI_PAGAMENTO,
            CASE WHEN :OPCPAGVI-DIA-DEBITO
            > 0
            THEN :OPCPAGVI-DIA-DEBITO
            ELSE DIA_DEBITO
            END,
            'VA0280B' ,
            CURRENT TIMESTAMP,
            CASE WHEN :OPCPAGVI-COD-AGENCIA-DEBITO
            > 0
            THEN :OPCPAGVI-COD-AGENCIA-DEBITO
            ELSE COD_AGENCIA_DEBITO
            END,
            CASE WHEN :OPCPAGVI-OPE-CONTA-DEBITO
            > 0
            THEN :OPCPAGVI-OPE-CONTA-DEBITO
            ELSE OPE_CONTA_DEBITO
            END,
            CASE WHEN :OPCPAGVI-NUM-CONTA-DEBITO
            > 0
            THEN :OPCPAGVI-NUM-CONTA-DEBITO
            ELSE NUM_CONTA_DEBITO
            END,
            CASE WHEN :OPCPAGVI-DIG-CONTA-DEBITO
            > 0
            THEN :OPCPAGVI-DIG-CONTA-DEBITO
            ELSE DIG_CONTA_DEBITO
            END,
            CASE WHEN :OPCPAGVI-NUM-CARTAO-CREDITO
            > 0
            THEN :OPCPAGVI-NUM-CARTAO-CREDITO
            ELSE NUM_CARTAO_CREDITO
            END
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :WSHOST-NUM-PROPOSTA
            AND DATA_TERVIGENCIA = :V1SIST-DTMOVABE-1
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL (NUM_CERTIFICADO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, OPCAO_PAGAMENTO, PERI_PAGAMENTO, DIA_DEBITO, COD_USUARIO, TIMESTAMP, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO) SELECT NUM_CERTIFICADO, {FieldThreatment(this.V1SIST_DTMOVABE)}, '9999-12-31' , OPCAO_PAGAMENTO, PERI_PAGAMENTO, CASE WHEN {FieldThreatment(this.OPCPAGVI_DIA_DEBITO)} > 0 THEN {FieldThreatment(this.OPCPAGVI_DIA_DEBITO)} ELSE DIA_DEBITO END, 'VA0280B' , CURRENT TIMESTAMP, CASE WHEN {FieldThreatment(this.OPCPAGVI_COD_AGENCIA_DEBITO)} > 0 THEN {FieldThreatment(this.OPCPAGVI_COD_AGENCIA_DEBITO)} ELSE COD_AGENCIA_DEBITO END, CASE WHEN {FieldThreatment(this.OPCPAGVI_OPE_CONTA_DEBITO)} > 0 THEN {FieldThreatment(this.OPCPAGVI_OPE_CONTA_DEBITO)} ELSE OPE_CONTA_DEBITO END, CASE WHEN {FieldThreatment(this.OPCPAGVI_NUM_CONTA_DEBITO)} > 0 THEN {FieldThreatment(this.OPCPAGVI_NUM_CONTA_DEBITO)} ELSE NUM_CONTA_DEBITO END, CASE WHEN {FieldThreatment(this.OPCPAGVI_DIG_CONTA_DEBITO)} > 0 THEN {FieldThreatment(this.OPCPAGVI_DIG_CONTA_DEBITO)} ELSE DIG_CONTA_DEBITO END, CASE WHEN {FieldThreatment(this.OPCPAGVI_NUM_CARTAO_CREDITO)} > 0 THEN {FieldThreatment(this.OPCPAGVI_NUM_CARTAO_CREDITO)} ELSE NUM_CARTAO_CREDITO END FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = {FieldThreatment(this.WSHOST_NUM_PROPOSTA)} AND DATA_TERVIGENCIA = {FieldThreatment(this.V1SIST_DTMOVABE_1)}";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string WSHOST_NUM_PROPOSTA { get; set; }
        public string V1SIST_DTMOVABE_1 { get; set; }

        public static void Execute(R1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1 r1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1)
        {
            var ths = r1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1390_00_TRATA_INF_CONTA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}