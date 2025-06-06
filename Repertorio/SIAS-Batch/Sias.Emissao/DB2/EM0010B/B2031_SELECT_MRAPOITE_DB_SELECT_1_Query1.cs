using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1 : QueryBasis<B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(PCT_DESC_FIDEL),0),
            VALUE(MAX(PCT_DESC_COMERCIAL),0)
            INTO :MRAPOITE-PCT-DESC-FIDEL ,
            :MRAPOITE-PCT-DESC-COMERCIAL
            FROM SEGUROS.MR_APOLICE_ITEM
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDO-NRENDOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(PCT_DESC_FIDEL)
							,0)
							,
											VALUE(MAX(PCT_DESC_COMERCIAL)
							,0)
											FROM SEGUROS.MR_APOLICE_ITEM
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDO_NRENDOS}'
											WITH UR";

            return query;
        }
        public string MRAPOITE_PCT_DESC_FIDEL { get; set; }
        public string MRAPOITE_PCT_DESC_COMERCIAL { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1 Execute(B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1 b2031_SELECT_MRAPOITE_DB_SELECT_1_Query1)
        {
            var ths = b2031_SELECT_MRAPOITE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1();
            var i = 0;
            dta.MRAPOITE_PCT_DESC_FIDEL = result[i++].Value?.ToString();
            dta.MRAPOITE_PCT_DESC_COMERCIAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}