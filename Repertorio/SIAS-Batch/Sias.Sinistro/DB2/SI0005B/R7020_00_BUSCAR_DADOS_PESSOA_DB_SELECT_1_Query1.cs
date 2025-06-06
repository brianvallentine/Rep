using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1 : QueryBasis<R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NUM_CNPJ
            ,B.NOM_FANTASIA
            INTO :GEPESJUR-NUM-CNPJ
            ,:GEPESJUR-NOM-FANTASIA
            FROM SEGUROS.GE_PESSOA A
            INNER JOIN SEGUROS.GE_PESSOA_JURIDICA B
            ON A.COD_PESSOA = B.COD_PESSOA
            WHERE B.COD_PESSOA = :GEPESSOA-COD-PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NUM_CNPJ
											,B.NOM_FANTASIA
											FROM SEGUROS.GE_PESSOA A
											INNER
							JOIN SEGUROS.GE_PESSOA_JURIDICA B
											ON A.COD_PESSOA = B.COD_PESSOA
											WHERE B.COD_PESSOA = '{this.GEPESSOA_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string GEPESJUR_NUM_CNPJ { get; set; }
        public string GEPESJUR_NOM_FANTASIA { get; set; }
        public string GEPESSOA_COD_PESSOA { get; set; }

        public static R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1 Execute(R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1 r7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = r7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEPESJUR_NUM_CNPJ = result[i++].Value?.ToString();
            dta.GEPESJUR_NOM_FANTASIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}