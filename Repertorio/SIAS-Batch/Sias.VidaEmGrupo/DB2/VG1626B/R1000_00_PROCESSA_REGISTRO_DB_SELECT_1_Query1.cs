using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(DATA_OPERACAO),DATE( '0001-12-31' ))
            INTO :WHOST-DATA-MOVIMVGA
            FROM SEGUROS.MOVIMENTO_VGAP
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO BETWEEN
            :WHOST-COD-SUBGRUPO-I
            AND :WHOST-COD-SUBGRUPO-F
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(DATA_OPERACAO)
							,DATE( '0001-12-31' ))
											FROM SEGUROS.MOVIMENTO_VGAP
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO BETWEEN
											'{this.WHOST_COD_SUBGRUPO_I}'
											AND '{this.WHOST_COD_SUBGRUPO_F}'";

            return query;
        }
        public string WHOST_DATA_MOVIMVGA { get; set; }
        public string WHOST_COD_SUBGRUPO_I { get; set; }
        public string WHOST_COD_SUBGRUPO_F { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATA_MOVIMVGA = result[i++].Value?.ToString();
            return dta;
        }

    }
}