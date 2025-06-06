using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2139B
{
    public class R1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1 : QueryBasis<R1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0PARCELA
            VALUES (:V0PARC-NUM-APOL ,
            :V0PARC-NRENDOS ,
            :V0PARC-NRPARCEL ,
            :V0PARC-DACPARC ,
            :V0PARC-FONTE ,
            :V0PARC-NRTIT ,
            :V0PARC-PRM-TAR-IX ,
            :V0PARC-VAL-DES-IX ,
            :V0PARC-OTNPRLIQ ,
            :V0PARC-OTNADFRA ,
            :V0PARC-OTNCUSTO ,
            :V0PARC-OTNIOF ,
            :V0PARC-OTNTOTAL ,
            :V0PARC-OCORHIST ,
            :V0PARC-QTDDOC ,
            :V0PARC-SITUACAO ,
            :V0PARC-COD-EMPRESA ,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PARCELA VALUES ({FieldThreatment(this.V0PARC_NUM_APOL)} , {FieldThreatment(this.V0PARC_NRENDOS)} , {FieldThreatment(this.V0PARC_NRPARCEL)} , {FieldThreatment(this.V0PARC_DACPARC)} , {FieldThreatment(this.V0PARC_FONTE)} , {FieldThreatment(this.V0PARC_NRTIT)} , {FieldThreatment(this.V0PARC_PRM_TAR_IX)} , {FieldThreatment(this.V0PARC_VAL_DES_IX)} , {FieldThreatment(this.V0PARC_OTNPRLIQ)} , {FieldThreatment(this.V0PARC_OTNADFRA)} , {FieldThreatment(this.V0PARC_OTNCUSTO)} , {FieldThreatment(this.V0PARC_OTNIOF)} , {FieldThreatment(this.V0PARC_OTNTOTAL)} , {FieldThreatment(this.V0PARC_OCORHIST)} , {FieldThreatment(this.V0PARC_QTDDOC)} , {FieldThreatment(this.V0PARC_SITUACAO)} , {FieldThreatment(this.V0PARC_COD_EMPRESA)} , CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string V0PARC_NUM_APOL { get; set; }
        public string V0PARC_NRENDOS { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0PARC_DACPARC { get; set; }
        public string V0PARC_FONTE { get; set; }
        public string V0PARC_NRTIT { get; set; }
        public string V0PARC_PRM_TAR_IX { get; set; }
        public string V0PARC_VAL_DES_IX { get; set; }
        public string V0PARC_OTNPRLIQ { get; set; }
        public string V0PARC_OTNADFRA { get; set; }
        public string V0PARC_OTNCUSTO { get; set; }
        public string V0PARC_OTNIOF { get; set; }
        public string V0PARC_OTNTOTAL { get; set; }
        public string V0PARC_OCORHIST { get; set; }
        public string V0PARC_QTDDOC { get; set; }
        public string V0PARC_SITUACAO { get; set; }
        public string V0PARC_COD_EMPRESA { get; set; }

        public static void Execute(R1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1 r1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1)
        {
            var ths = r1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1350_00_GRAVA_V0PARCELA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}