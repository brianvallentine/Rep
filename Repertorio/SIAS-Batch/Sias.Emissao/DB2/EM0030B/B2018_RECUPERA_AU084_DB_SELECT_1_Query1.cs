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
    public class B2018_RECUPERA_AU084_DB_SELECT_1_Query1 : QueryBasis<B2018_RECUPERA_AU084_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_FORMA_PAGTO_AD
            INTO :AU084-IND-FORMA-PAGTO-AD
            FROM SEGUROS.AU_APOLICE_COMPL
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDO-NRENDOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IND_FORMA_PAGTO_AD
											FROM SEGUROS.AU_APOLICE_COMPL
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDO_NRENDOS}'
											WITH UR";

            return query;
        }
        public string AU084_IND_FORMA_PAGTO_AD { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static B2018_RECUPERA_AU084_DB_SELECT_1_Query1 Execute(B2018_RECUPERA_AU084_DB_SELECT_1_Query1 b2018_RECUPERA_AU084_DB_SELECT_1_Query1)
        {
            var ths = b2018_RECUPERA_AU084_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B2018_RECUPERA_AU084_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B2018_RECUPERA_AU084_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU084_IND_FORMA_PAGTO_AD = result[i++].Value?.ToString();
            return dta;
        }

    }
}