using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1 : QueryBasis<B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FONTE ,
            NRRCAP ,
            BCOAVISO ,
            AGEAVISO ,
            NRAVISO ,
            OPERACAO
            INTO :PCOM-FONTE ,
            :PCOM-NRRCAP ,
            :PCOM-BCOAVISO ,
            :PCOM-AGEAVISO ,
            :PCOM-NRAVISO ,
            :PCOM-OPERACAO
            FROM SEGUROS.V1RCAPCOMP
            WHERE NRRCAP = :ENDO-NRRCAP
            AND NRRCAPCO = 0
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT FONTE 
							,
											NRRCAP 
							,
											BCOAVISO 
							,
											AGEAVISO 
							,
											NRAVISO 
							,
											OPERACAO
											FROM SEGUROS.V1RCAPCOMP
											WHERE NRRCAP = '{this.ENDO_NRRCAP}'
											AND NRRCAPCO = 0
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string PCOM_FONTE { get; set; }
        public string PCOM_NRRCAP { get; set; }
        public string PCOM_BCOAVISO { get; set; }
        public string PCOM_AGEAVISO { get; set; }
        public string PCOM_NRAVISO { get; set; }
        public string PCOM_OPERACAO { get; set; }
        public string ENDO_NRRCAP { get; set; }

        public static B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1 Execute(B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1 b3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1)
        {
            var ths = b3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.PCOM_FONTE = result[i++].Value?.ToString();
            dta.PCOM_NRRCAP = result[i++].Value?.ToString();
            dta.PCOM_BCOAVISO = result[i++].Value?.ToString();
            dta.PCOM_AGEAVISO = result[i++].Value?.ToString();
            dta.PCOM_NRAVISO = result[i++].Value?.ToString();
            dta.PCOM_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}