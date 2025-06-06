using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0414B
{
    public class R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CONTA_DEBITO ,
            DIG_CONTA_DEBITO ,
            DIA_DEBITO ,
            COD_AGENCIA_DEBITO ,
            OPE_CONTA_DEBITO ,
            NUM_CARTAO_CREDITO
            INTO :OPCPAGVI-NUM-CONTA-DEBITO:WIND-CTADEB ,
            :OPCPAGVI-DIG-CONTA-DEBITO:WIND-DGCTA ,
            :OPCPAGVI-DIA-DEBITO ,
            :OPCPAGVI-COD-AGENCIA-DEBITO:WIND-AGENCIA ,
            :OPCPAGVI-OPE-CONTA-DEBITO:WIND-OPER ,
            :OPCPAGVI-NUM-CARTAO-CREDITO:WIND-CARTAO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO =
            :DCLRELATORIOS.RELATORI-NUM-TITULO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CONTA_DEBITO 
							,
											DIG_CONTA_DEBITO 
							,
											DIA_DEBITO 
							,
											COD_AGENCIA_DEBITO 
							,
											OPE_CONTA_DEBITO 
							,
											NUM_CARTAO_CREDITO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO =
											'{this.RELATORI_NUM_TITULO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string WIND_CTADEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string WIND_DGCTA { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string WIND_AGENCIA { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string WIND_OPER { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string WIND_CARTAO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }

        public static R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1 r1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_OPCAO_PAG_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.WIND_CTADEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.WIND_DGCTA = string.IsNullOrWhiteSpace(dta.OPCPAGVI_DIG_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIA_DEBITO = result[i++].Value?.ToString();
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.WIND_AGENCIA = string.IsNullOrWhiteSpace(dta.OPCPAGVI_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.WIND_OPER = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            dta.WIND_CARTAO = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CARTAO_CREDITO) ? "-1" : "0";
            return dta;
        }

    }
}