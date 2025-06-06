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
    public class A4200_LE_AU085_DB_SELECT_1_Query1 : QueryBasis<A4200_LE_AU085_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(IND_FORMA_PAGTO_AD, '0' )
            INTO :AU085-IND-FORMA-PAGTO-AD
            FROM SEGUROS.AU_PROPOSTA_COMPL
            WHERE COD_FONTE = :ENDO-FONTE
            AND NUM_PROPOSTA = :ENDO-NRPROPOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(IND_FORMA_PAGTO_AD
							, '0' )
											FROM SEGUROS.AU_PROPOSTA_COMPL
											WHERE COD_FONTE = '{this.ENDO_FONTE}'
											AND NUM_PROPOSTA = '{this.ENDO_NRPROPOS}'
											WITH UR";

            return query;
        }
        public string AU085_IND_FORMA_PAGTO_AD { get; set; }
        public string ENDO_NRPROPOS { get; set; }
        public string ENDO_FONTE { get; set; }

        public static A4200_LE_AU085_DB_SELECT_1_Query1 Execute(A4200_LE_AU085_DB_SELECT_1_Query1 a4200_LE_AU085_DB_SELECT_1_Query1)
        {
            var ths = a4200_LE_AU085_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A4200_LE_AU085_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A4200_LE_AU085_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU085_IND_FORMA_PAGTO_AD = result[i++].Value?.ToString();
            return dta;
        }

    }
}