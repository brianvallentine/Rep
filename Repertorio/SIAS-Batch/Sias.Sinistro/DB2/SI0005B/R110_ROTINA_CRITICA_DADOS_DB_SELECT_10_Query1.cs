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
    public class R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1 : QueryBasis<R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-ACHA-LOTERICO
            FROM SEGUROS.SINI_LOTERICO01 S
            ,SEGUROS.SINISTRO_MESTRE M
            ,SEGUROS.SINISTRO_CAUSA C
            ,SEGUROS.SI_MOV_LOTERICO1 D
            WHERE S.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND S.COD_COBERTURA = :LOTCOB01-COD-COBERTURA
            AND S.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            AND S.COD_LOT_CEF = :LOTERI01-COD-LOT-CEF
            AND M.NUM_APOL_SINISTRO = S.NUM_APOL_SINISTRO
            AND S.COD_LOT_CEF = D.COD_LOT_CEF
            AND M.NUM_APOL_SINISTRO = D.NUM_APOL_SINISTRO
            AND M.DATA_OCORRENCIA = D.DATA_OCORRENCIA
            AND D.HORA_OCORRENCIA = :HOST-HORA-OCORRENCIA
            AND M.DATA_OCORRENCIA = :HOST-DATA-OCORRENCIA
            AND M.DATA_COMUNICADO = :HOST-DATA-AVISO
            AND M.SIT_REGISTRO <> '2'
            AND C.RAMO_EMISSOR = M.RAMO
            AND C.COD_CAUSA = M.COD_CAUSA
            AND C.GRUPO_CAUSAS = :SINISCAU-GRUPO-CAUSAS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.SINI_LOTERICO01 S
											,SEGUROS.SINISTRO_MESTRE M
											,SEGUROS.SINISTRO_CAUSA C
											,SEGUROS.SI_MOV_LOTERICO1 D
											WHERE S.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND S.COD_COBERTURA = '{this.LOTCOB01_COD_COBERTURA}'
											AND S.COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											AND S.COD_LOT_CEF = '{this.LOTERI01_COD_LOT_CEF}'
											AND M.NUM_APOL_SINISTRO = S.NUM_APOL_SINISTRO
											AND S.COD_LOT_CEF = D.COD_LOT_CEF
											AND M.NUM_APOL_SINISTRO = D.NUM_APOL_SINISTRO
											AND M.DATA_OCORRENCIA = D.DATA_OCORRENCIA
											AND D.HORA_OCORRENCIA = '{this.HOST_HORA_OCORRENCIA}'
											AND M.DATA_OCORRENCIA = '{this.HOST_DATA_OCORRENCIA}'
											AND M.DATA_COMUNICADO = '{this.HOST_DATA_AVISO}'
											AND M.SIT_REGISTRO <> '2'
											AND C.RAMO_EMISSOR = M.RAMO
											AND C.COD_CAUSA = M.COD_CAUSA
											AND C.GRUPO_CAUSAS = '{this.SINISCAU_GRUPO_CAUSAS}'";

            return query;
        }
        public string HOST_ACHA_LOTERICO { get; set; }
        public string LOTCOB01_COD_COBERTURA { get; set; }
        public string LOTERI01_COD_LOT_FENAL { get; set; }
        public string SINISCAU_GRUPO_CAUSAS { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }
        public string LOTERI01_COD_LOT_CEF { get; set; }
        public string HOST_HORA_OCORRENCIA { get; set; }
        public string HOST_DATA_OCORRENCIA { get; set; }
        public string HOST_DATA_AVISO { get; set; }

        public static R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1 Execute(R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1 r110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1)
        {
            var ths = r110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R110_ROTINA_CRITICA_DADOS_DB_SELECT_10_Query1();
            var i = 0;
            dta.HOST_ACHA_LOTERICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}