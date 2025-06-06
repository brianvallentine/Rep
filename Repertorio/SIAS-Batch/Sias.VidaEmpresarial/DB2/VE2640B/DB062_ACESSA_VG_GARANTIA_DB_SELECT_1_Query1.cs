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
    public class DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1 : QueryBasis<DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_GARANTIA
            INTO :VGARANTI-DES-GARANTIA
            FROM SEGUROS.VG_GARANTIA
            WHERE NUM_GARANTIA = :VGARANTI-NUM-GARANTIA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DES_GARANTIA
											FROM SEGUROS.VG_GARANTIA
											WHERE NUM_GARANTIA = '{this.VGARANTI_NUM_GARANTIA}'";

            return query;
        }
        public string VGARANTI_DES_GARANTIA { get; set; }
        public string VGARANTI_NUM_GARANTIA { get; set; }

        public static DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1 Execute(DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1 dB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1)
        {
            var ths = dB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB062_ACESSA_VG_GARANTIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGARANTI_DES_GARANTIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}