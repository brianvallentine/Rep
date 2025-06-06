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
    public class B2000_CONTINUA_DB_SELECT_2_Query1 : QueryBasis<B2000_CONTINUA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_FATURA, VLIOCC
            INTO :FATU-VLPRMTOT, :FATU-VLIOCC
            FROM SEGUROS.V0FATURASFIL
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND NRENDOS = :ENDO-NRENDOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_FATURA
							, VLIOCC
											FROM SEGUROS.V0FATURASFIL
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND NRENDOS = '{this.ENDO_NRENDOS}'
											WITH UR";

            return query;
        }
        public string FATU_VLPRMTOT { get; set; }
        public string FATU_VLIOCC { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2000_CONTINUA_DB_SELECT_2_Query1 Execute(B2000_CONTINUA_DB_SELECT_2_Query1 b2000_CONTINUA_DB_SELECT_2_Query1)
        {
            var ths = b2000_CONTINUA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2000_CONTINUA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2000_CONTINUA_DB_SELECT_2_Query1();
            var i = 0;
            dta.FATU_VLPRMTOT = result[i++].Value?.ToString();
            dta.FATU_VLIOCC = result[i++].Value?.ToString();
            return dta;
        }

    }
}