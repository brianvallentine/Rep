using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 : QueryBasis<R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.IMP_SEGURADA_IX
            INTO :VGCOBSUB-IMP-SEGURADA-IX
            FROM SEGUROS.VG_COBERTURAS_SUBG T1
            LEFT JOIN SEGUROS.VG_COBER_SUBG_HIST T2
            ON (T2.NUM_APOLICE = T1.NUM_APOLICE
            AND T2.COD_SUBGRUPO = T1.COD_SUBGRUPO
            AND T2.COD_COBERTURA = T1.COD_COBERTURA)
            WHERE T1.NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND T1.COD_SUBGRUPO = :V0PROP-CODSUBES
            AND T1.COD_COBERTURA =
            :VGCOBSUB-COD-COBERTURA
            AND ((T1.SIT_COBERTURA = '0' )
            OR (T1.SIT_COBERTURA = '1'
            AND T1.NUM_APOLICE = T2.NUM_APOLICE
            AND T1.COD_SUBGRUPO = T2.COD_SUBGRUPO
            AND T1.COD_COBERTURA = T2.COD_COBERTURA
            AND T2.DATA_TERVIGENCIA > :V0PROP-DTQITBCO
            AND T2.DATA_TERVIGENCIA =
            (SELECT MAX(T3.DATA_TERVIGENCIA)
            FROM SEGUROS.VG_COBER_SUBG_HIST T3
            WHERE T3.NUM_APOLICE = T1.NUM_APOLICE
            AND T3.COD_COBERTURA = T1.COD_COBERTURA
            AND T3.COD_SUBGRUPO = T1.COD_SUBGRUPO
            AND T3.DATA_TERVIGENCIA <> '9999-12-31' )
            AND NOT EXISTS
            (SELECT T4.COD_COBERTURA
            FROM SEGUROS.VG_COBER_SUBG_HIST T4
            WHERE T4.NUM_APOLICE =
            T1.NUM_APOLICE
            AND T4.COD_SUBGRUPO =
            T1.COD_SUBGRUPO
            AND T4.COD_COBERTURA = 22
            AND T1.COD_COBERTURA = 01
            AND ((T4.DATA_TERVIGENCIA =
            '9999-12-31' )
            OR (T4.DATA_TERVIGENCIA >=
            T2.DATA_TERVIGENCIA)))))
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T1.IMP_SEGURADA_IX
											FROM SEGUROS.VG_COBERTURAS_SUBG T1
											LEFT
							JOIN SEGUROS.VG_COBER_SUBG_HIST T2
											ON (T2.NUM_APOLICE = T1.NUM_APOLICE
											AND T2.COD_SUBGRUPO = T1.COD_SUBGRUPO
											AND T2.COD_COBERTURA = T1.COD_COBERTURA)
											WHERE T1.NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND T1.COD_SUBGRUPO = '{this.V0PROP_CODSUBES}'
											AND T1.COD_COBERTURA =
											'{this.VGCOBSUB_COD_COBERTURA}'
											AND ((T1.SIT_COBERTURA = '0' )
											OR (T1.SIT_COBERTURA = '1'
											AND T1.NUM_APOLICE = T2.NUM_APOLICE
											AND T1.COD_SUBGRUPO = T2.COD_SUBGRUPO
											AND T1.COD_COBERTURA = T2.COD_COBERTURA
											AND T2.DATA_TERVIGENCIA > '{this.V0PROP_DTQITBCO}'
											AND T2.DATA_TERVIGENCIA =
											(SELECT MAX(T3.DATA_TERVIGENCIA)
											FROM SEGUROS.VG_COBER_SUBG_HIST T3
											WHERE T3.NUM_APOLICE = T1.NUM_APOLICE
											AND T3.COD_COBERTURA = T1.COD_COBERTURA
											AND T3.COD_SUBGRUPO = T1.COD_SUBGRUPO
											AND T3.DATA_TERVIGENCIA <> '9999-12-31' )
											AND NOT EXISTS
											(SELECT T4.COD_COBERTURA
											FROM SEGUROS.VG_COBER_SUBG_HIST T4
											WHERE T4.NUM_APOLICE =
											T1.NUM_APOLICE
											AND T4.COD_SUBGRUPO =
											T1.COD_SUBGRUPO
											AND T4.COD_COBERTURA = 22
											AND T1.COD_COBERTURA = 01
											AND ((T4.DATA_TERVIGENCIA =
											'9999-12-31' )
											OR (T4.DATA_TERVIGENCIA >=
											T2.DATA_TERVIGENCIA)))))
											WITH UR";

            return query;
        }
        public string VGCOBSUB_IMP_SEGURADA_IX { get; set; }
        public string VGCOBSUB_COD_COBERTURA { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_DTQITBCO { get; set; }

        public static R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 Execute(R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 r7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1)
        {
            var ths = r7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1();
            var i = 0;
            dta.VGCOBSUB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}