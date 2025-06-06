using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1 : QueryBasis<R0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.VG_REPRES_LEGAL
            (
            COD_PESSOA
            ,NUM_OCORR_HIST
            ,NUM_APOLICE
            ,COD_SUBGRUPO
            ,VLR_RENDA
            )
            VALUES (:DCLPESSOA.PESSOA-COD-PESSOA ,
            :VG093-NUM-OCORR-HIST ,
            :VG093-NUM-APOLICE ,
            :VG093-COD-SUBGRUPO ,
            :VG093-VLR-RENDA )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_REPRES_LEGAL ( COD_PESSOA ,NUM_OCORR_HIST ,NUM_APOLICE ,COD_SUBGRUPO ,VLR_RENDA ) VALUES ({FieldThreatment(this.PESSOA_COD_PESSOA)} , {FieldThreatment(this.VG093_NUM_OCORR_HIST)} , {FieldThreatment(this.VG093_NUM_APOLICE)} , {FieldThreatment(this.VG093_COD_SUBGRUPO)} , {FieldThreatment(this.VG093_VLR_RENDA)} )";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string VG093_NUM_OCORR_HIST { get; set; }
        public string VG093_NUM_APOLICE { get; set; }
        public string VG093_COD_SUBGRUPO { get; set; }
        public string VG093_VLR_RENDA { get; set; }

        public static void Execute(R0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1 r0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1)
        {
            var ths = r0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0546_00_INSERT_REPRES_LEGAL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}