using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 : QueryBasis<R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT AGECOBR ,
            NUM_MATRICULA ,
            COD_AGENCIA ,
            OPERACAO_CONTA ,
            NUM_CONTA ,
            DIG_CONTA ,
            DTQITBCO ,
            VLRCAP ,
            SITUACAO
            INTO :V0CFEN-AGECOBR ,
            :V0CFEN-MATRICULA ,
            :V0CFEN-AGECONTA ,
            :V0CFEN-OPECONTA ,
            :V0CFEN-NUMCONTA ,
            :V0CFEN-DIGCONTA ,
            :V0CFEN-DTQITBCO ,
            :V0CFEN-VLRCAP ,
            :V0CFEN-SITUACAO
            FROM SEGUROS.V0COMISSAO_FENAE
            WHERE NUMBIL = :V0BILH-NUMBIL
            AND NUM_MATRICULA NOT IN (8888888,9999999)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT AGECOBR 
							,
											NUM_MATRICULA 
							,
											COD_AGENCIA 
							,
											OPERACAO_CONTA 
							,
											NUM_CONTA 
							,
											DIG_CONTA 
							,
											DTQITBCO 
							,
											VLRCAP 
							,
											SITUACAO
											FROM SEGUROS.V0COMISSAO_FENAE
											WHERE NUMBIL = '{this.V0BILH_NUMBIL}'
											AND NUM_MATRICULA NOT IN (8888888
							,9999999)";

            return query;
        }
        public string V0CFEN_AGECOBR { get; set; }
        public string V0CFEN_MATRICULA { get; set; }
        public string V0CFEN_AGECONTA { get; set; }
        public string V0CFEN_OPECONTA { get; set; }
        public string V0CFEN_NUMCONTA { get; set; }
        public string V0CFEN_DIGCONTA { get; set; }
        public string V0CFEN_DTQITBCO { get; set; }
        public string V0CFEN_VLRCAP { get; set; }
        public string V0CFEN_SITUACAO { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 Execute(R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 r0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1)
        {
            var ths = r0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0470_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CFEN_AGECOBR = result[i++].Value?.ToString();
            dta.V0CFEN_MATRICULA = result[i++].Value?.ToString();
            dta.V0CFEN_AGECONTA = result[i++].Value?.ToString();
            dta.V0CFEN_OPECONTA = result[i++].Value?.ToString();
            dta.V0CFEN_NUMCONTA = result[i++].Value?.ToString();
            dta.V0CFEN_DIGCONTA = result[i++].Value?.ToString();
            dta.V0CFEN_DTQITBCO = result[i++].Value?.ToString();
            dta.V0CFEN_VLRCAP = result[i++].Value?.ToString();
            dta.V0CFEN_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}