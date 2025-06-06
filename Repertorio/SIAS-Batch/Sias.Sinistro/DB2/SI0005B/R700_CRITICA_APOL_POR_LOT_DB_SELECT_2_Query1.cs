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
    public class R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1 : QueryBasis<R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(IMP_SEGURADA_IX,0)
            ,DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
            INTO :OUTROCOB-IMP-SEGURADA-IX
            ,:OUTROCOB-DATA-INIVIGENCIA
            ,:OUTROCOB-DATA-TERVIGENCIA
            FROM SEGUROS.OUTROS_COBERTURAS
            WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR
            AND MODALI_COBERTURA = :APOLICES-COD-MODALIDADE
            AND COD_COBERTURA = :OUTROCOB-COD-COBERTURA
            AND DATA_INIVIGENCIA =
            ( SELECT MAX(T1.DATA_INIVIGENCIA)
            FROM SEGUROS.OUTROS_COBERTURAS T1
            ,SEGUROS.ENDOSSOS T2
            WHERE T1.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND T1.RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR
            AND T1.MODALI_COBERTURA =
            :APOLICES-COD-MODALIDADE
            AND T1.COD_COBERTURA =
            :OUTROCOB-COD-COBERTURA
            AND T1.DATA_INIVIGENCIA <= :HOST-DATA-OCORRENCIA
            AND T1.DATA_TERVIGENCIA >= :HOST-DATA-OCORRENCIA
            AND T1.NUM_APOLICE = T2.NUM_APOLICE
            AND T1.NUM_ENDOSSO = T2.NUM_ENDOSSO
            AND T2.TIPO_ENDOSSO <> :WS-TIPO-ENDOSSO
            )
            AND TIMESTAMP =
            ( SELECT MAX(T3.TIMESTAMP)
            FROM SEGUROS.OUTROS_COBERTURAS T3,
            SEGUROS.ENDOSSOS T4
            WHERE T3.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND T3.RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR
            AND T3.MODALI_COBERTURA =
            :APOLICES-COD-MODALIDADE
            AND T3.COD_COBERTURA =
            :OUTROCOB-COD-COBERTURA
            AND T3.DATA_INIVIGENCIA <= :HOST-DATA-OCORRENCIA
            AND T3.DATA_TERVIGENCIA >= :HOST-DATA-OCORRENCIA
            AND T3.NUM_APOLICE = T4.NUM_APOLICE
            AND T3.NUM_ENDOSSO = T4.NUM_ENDOSSO
            AND T4.TIPO_ENDOSSO <> :WS-TIPO-ENDOSSO
            )
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(IMP_SEGURADA_IX
							,0)
											,DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
											FROM SEGUROS.OUTROS_COBERTURAS
											WHERE NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND RAMO_COBERTURA = '{this.APOLICES_RAMO_EMISSOR}'
											AND MODALI_COBERTURA = '{this.APOLICES_COD_MODALIDADE}'
											AND COD_COBERTURA = '{this.OUTROCOB_COD_COBERTURA}'
											AND DATA_INIVIGENCIA =
											( SELECT MAX(T1.DATA_INIVIGENCIA)
											FROM SEGUROS.OUTROS_COBERTURAS T1
											,SEGUROS.ENDOSSOS T2
											WHERE T1.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND T1.RAMO_COBERTURA = '{this.APOLICES_RAMO_EMISSOR}'
											AND T1.MODALI_COBERTURA =
											'{this.APOLICES_COD_MODALIDADE}'
											AND T1.COD_COBERTURA =
											'{this.OUTROCOB_COD_COBERTURA}'
											AND T1.DATA_INIVIGENCIA <= '{this.HOST_DATA_OCORRENCIA}'
											AND T1.DATA_TERVIGENCIA >= '{this.HOST_DATA_OCORRENCIA}'
											AND T1.NUM_APOLICE = T2.NUM_APOLICE
											AND T1.NUM_ENDOSSO = T2.NUM_ENDOSSO
											AND T2.TIPO_ENDOSSO <> '{this.WS_TIPO_ENDOSSO}'
											)
											AND TIMESTAMP =
											( SELECT MAX(T3.TIMESTAMP)
											FROM SEGUROS.OUTROS_COBERTURAS T3
							,
											SEGUROS.ENDOSSOS T4
											WHERE T3.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND T3.RAMO_COBERTURA = '{this.APOLICES_RAMO_EMISSOR}'
											AND T3.MODALI_COBERTURA =
											'{this.APOLICES_COD_MODALIDADE}'
											AND T3.COD_COBERTURA =
											'{this.OUTROCOB_COD_COBERTURA}'
											AND T3.DATA_INIVIGENCIA <= '{this.HOST_DATA_OCORRENCIA}'
											AND T3.DATA_TERVIGENCIA >= '{this.HOST_DATA_OCORRENCIA}'
											AND T3.NUM_APOLICE = T4.NUM_APOLICE
											AND T3.NUM_ENDOSSO = T4.NUM_ENDOSSO
											AND T4.TIPO_ENDOSSO <> '{this.WS_TIPO_ENDOSSO}'
											)
											WITH UR";

            return query;
        }
        public string OUTROCOB_IMP_SEGURADA_IX { get; set; }
        public string OUTROCOB_DATA_INIVIGENCIA { get; set; }
        public string OUTROCOB_DATA_TERVIGENCIA { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string OUTROCOB_COD_COBERTURA { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }
        public string HOST_DATA_OCORRENCIA { get; set; }
        public string WS_TIPO_ENDOSSO { get; set; }

        public static R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1 Execute(R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1 r700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1)
        {
            var ths = r700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R700_CRITICA_APOL_POR_LOT_DB_SELECT_2_Query1();
            var i = 0;
            dta.OUTROCOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.OUTROCOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.OUTROCOB_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}