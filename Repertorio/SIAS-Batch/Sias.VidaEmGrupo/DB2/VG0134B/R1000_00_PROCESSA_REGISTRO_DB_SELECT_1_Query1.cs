using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0134B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX
            INTO :HOST-IMP-SEGURADA-IX
            FROM SEGUROS.VG_COBERTURAS_SUBG
            WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE
            AND COD_SUBGRUPO = :RELATORI-COD-SUBGRUPO
            AND COD_COBERTURA = :RELATORI-COD-PLANO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
											FROM SEGUROS.VG_COBERTURAS_SUBG
											WHERE NUM_APOLICE = '{this.RELATORI_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.RELATORI_COD_SUBGRUPO}'
											AND COD_COBERTURA = '{this.RELATORI_COD_PLANO}'
											WITH UR";

            return query;
        }
        public string HOST_IMP_SEGURADA_IX { get; set; }
        public string RELATORI_COD_SUBGRUPO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_COD_PLANO { get; set; }

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
            dta.HOST_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}