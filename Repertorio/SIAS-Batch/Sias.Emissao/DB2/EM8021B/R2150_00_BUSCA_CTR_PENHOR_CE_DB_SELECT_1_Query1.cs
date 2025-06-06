using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8021B
{
    public class R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1 : QueryBasis<R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(NUM_CONTRATO,0) ,
            VALUE(COD_AGENCIA,630)
            INTO :SINIPENH-NUM-CONTRATO ,
            :SINIPENH-COD-AGENCIA
            FROM SEGUROS.SINI_PENHOR01
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(NUM_CONTRATO
							,0) 
							,
											VALUE(COD_AGENCIA
							,630)
											FROM SEGUROS.SINI_PENHOR01
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINIPENH_NUM_CONTRATO { get; set; }
        public string SINIPENH_COD_AGENCIA { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1 Execute(R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1 r2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1)
        {
            var ths = r2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIPENH_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.SINIPENH_COD_AGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}