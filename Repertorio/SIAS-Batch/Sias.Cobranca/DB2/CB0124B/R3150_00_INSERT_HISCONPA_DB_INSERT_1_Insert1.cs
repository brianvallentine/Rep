using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0124B
{
    public class R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1 : QueryBasis<R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.HIST_CONT_PARCELVA
            ( NUM_CERTIFICADO
            , NUM_PARCELA
            , NUM_TITULO
            , OCORR_HISTORICO
            , NUM_APOLICE
            , COD_SUBGRUPO
            , COD_FONTE
            , NUM_ENDOSSO
            , PREMIO_VG
            , PREMIO_AP
            , DATA_MOVIMENTO
            , SIT_REGISTRO
            , COD_OPERACAO
            , TIMESTAMP
            , DTFATUR
            )
            VALUES
            ( :HISCONPA-NUM-CERTIFICADO
            , :HISCONPA-NUM-PARCELA
            , :HISCONPA-NUM-TITULO
            , :HISCONPA-OCORR-HISTORICO
            , :HISCONPA-NUM-APOLICE
            , :HISCONPA-COD-SUBGRUPO
            , :HISCONPA-COD-FONTE
            , :HISCONPA-NUM-ENDOSSO
            , :HISCONPA-PREMIO-VG
            , :HISCONPA-PREMIO-AP
            , :HISCONPA-DATA-MOVIMENTO
            , :HISCONPA-SIT-REGISTRO
            , :HISCONPA-COD-OPERACAO
            , CURRENT TIMESTAMP
            , :HISCONPA-DTFATUR:VIND-DTFATUR
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_CONT_PARCELVA ( NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_ENDOSSO , PREMIO_VG , PREMIO_AP , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , TIMESTAMP , DTFATUR ) VALUES ( {FieldThreatment(this.HISCONPA_NUM_CERTIFICADO)} , {FieldThreatment(this.HISCONPA_NUM_PARCELA)} , {FieldThreatment(this.HISCONPA_NUM_TITULO)} , {FieldThreatment(this.HISCONPA_OCORR_HISTORICO)} , {FieldThreatment(this.HISCONPA_NUM_APOLICE)} , {FieldThreatment(this.HISCONPA_COD_SUBGRUPO)} , {FieldThreatment(this.HISCONPA_COD_FONTE)} , {FieldThreatment(this.HISCONPA_NUM_ENDOSSO)} , {FieldThreatment(this.HISCONPA_PREMIO_VG)} , {FieldThreatment(this.HISCONPA_PREMIO_AP)} , {FieldThreatment(this.HISCONPA_DATA_MOVIMENTO)} , {FieldThreatment(this.HISCONPA_SIT_REGISTRO)} , {FieldThreatment(this.HISCONPA_COD_OPERACAO)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_DTFATUR?.ToInt() == -1 ? null : this.HISCONPA_DTFATUR))} )";

            return query;
        }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string HISCONPA_NUM_TITULO { get; set; }
        public string HISCONPA_OCORR_HISTORICO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_COD_SUBGRUPO { get; set; }
        public string HISCONPA_COD_FONTE { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }
        public string HISCONPA_PREMIO_VG { get; set; }
        public string HISCONPA_PREMIO_AP { get; set; }
        public string HISCONPA_DATA_MOVIMENTO { get; set; }
        public string HISCONPA_SIT_REGISTRO { get; set; }
        public string HISCONPA_COD_OPERACAO { get; set; }
        public string HISCONPA_DTFATUR { get; set; }
        public string VIND_DTFATUR { get; set; }

        public static void Execute(R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1 r3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1)
        {
            var ths = r3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3150_00_INSERT_HISCONPA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}