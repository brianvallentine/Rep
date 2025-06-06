using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0656B
{
    public class R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1 : QueryBasis<R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_PAGAMENTO ,
            COD_AGENCIA_DEBITO ,
            OPE_CONTA_DEBITO ,
            NUM_CONTA_DEBITO ,
            DIG_CONTA_DEBITO ,
            NUM_CARTAO_CREDITO
            INTO :OPCPAGVI-OPCAO-PAGAMENTO:VIND-OPE-PAG ,
            :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGENCIA ,
            :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPER ,
            :OPCPAGVI-NUM-CONTA-DEBITO:VIND-CTADEB ,
            :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DGCTA ,
            :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CARTAO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAO_PAGAMENTO 
							,
											COD_AGENCIA_DEBITO 
							,
											OPE_CONTA_DEBITO 
							,
											NUM_CONTA_DEBITO 
							,
											DIG_CONTA_DEBITO 
							,
											NUM_CARTAO_CREDITO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.OPCPAGVI_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string VIND_OPE_PAG { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGENCIA { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPER { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_CTADEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DGCTA { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_CARTAO { get; set; }
        public string OPCPAGVI_NUM_CERTIFICADO { get; set; }

        public static R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1 Execute(R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1 r2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1)
        {
            var ths = r2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.VIND_OPE_PAG = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPCAO_PAGAMENTO) ? "-1" : "0";
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_AGENCIA = string.IsNullOrWhiteSpace(dta.OPCPAGVI_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_OPER = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_CTADEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DGCTA = string.IsNullOrWhiteSpace(dta.OPCPAGVI_DIG_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            dta.VIND_CARTAO = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CARTAO_CREDITO) ? "-1" : "0";
            return dta;
        }

    }
}