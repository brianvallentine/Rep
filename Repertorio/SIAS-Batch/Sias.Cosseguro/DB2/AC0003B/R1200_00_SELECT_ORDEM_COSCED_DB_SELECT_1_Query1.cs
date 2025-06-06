using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0003B
{
    public class R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE,
            NUM_ENDOSSO,
            COD_COSSEGURADORA,
            ORDEM_CEDIDO
            INTO :ORDEMCOS-NUM-APOLICE,
            :ORDEMCOS-NUM-ENDOSSO,
            :ORDEMCOS-COD-COSSEGURADORA,
            :ORDEMCOS-ORDEM-CEDIDO
            FROM SEGUROS.ORDEM_COSSEGCED
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-ENDOS-CANCELA
            AND COD_COSSEGURADORA = :APOLCOSS-COD-COSSEGURADORA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
							,
											NUM_ENDOSSO
							,
											COD_COSSEGURADORA
							,
											ORDEM_CEDIDO
											FROM SEGUROS.ORDEM_COSSEGCED
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_ENDOS_CANCELA}'
											AND COD_COSSEGURADORA = '{this.APOLCOSS_COD_COSSEGURADORA}'";

            return query;
        }
        public string ORDEMCOS_NUM_APOLICE { get; set; }
        public string ORDEMCOS_NUM_ENDOSSO { get; set; }
        public string ORDEMCOS_COD_COSSEGURADORA { get; set; }
        public string ORDEMCOS_ORDEM_CEDIDO { get; set; }
        public string APOLCOSS_COD_COSSEGURADORA { get; set; }
        public string PARCEHIS_ENDOS_CANCELA { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }

        public static R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1 r1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1();
            var i = 0;
            dta.ORDEMCOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ORDEMCOS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.ORDEMCOS_COD_COSSEGURADORA = result[i++].Value?.ToString();
            dta.ORDEMCOS_ORDEM_CEDIDO = result[i++].Value?.ToString();
            return dta;
        }

    }
}